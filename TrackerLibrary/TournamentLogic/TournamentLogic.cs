using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.TournamentLogic
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel Model)
        {
            //Order our list randomly
            List<TeamModel> RandomizedTeams = RandomizeTeamOrder(Model.EnteredTeams);

            //Check if the list is big enough - If not, add in byes (empty teams)
            int Rounds = FindNumberOfRounds(RandomizedTeams.Count);
            int Byes = NumberOfByes(Rounds, RandomizedTeams.Count);

            //Create the first round of matchups
            Model.Rounds.Add(CreateFirstRound(Byes, RandomizedTeams));

            //Create every round after that
            CreateOtherRounds(Model, Rounds);

            UpdateTournamentResults(Model);
        }
        public static void UpdateTournamentResults(TournamentModel Model)
        {
            int StartingRound = Model.CheckCurrentRound();
            List<MatchupModel> ToScore = new List<MatchupModel>();

            foreach (List<MatchupModel> Round in Model.Rounds)
            {
                foreach (MatchupModel Rm in Round)
                {
                    if (Rm.Winner == null && (Rm.Entries.Any(x => x.Score != 0) || Rm.Entries.Count == 1))
                    {
                        ToScore.Add(Rm);
                    }
                }
            }
            MarkWinnerInMatchups(ToScore);

            AdvanceWinners(ToScore, Model);

            ToScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
            int EndingRound = Model.CheckCurrentRound();
            if (EndingRound > StartingRound)
            {
                //Alert Users
                Model.AlertUsersToNewRound();
            }
        }
        public static void AlertUsersToNewRound(this TournamentModel Model)
        {
            int CurrentRoundNumber = Model.CheckCurrentRound();
            List<MatchupModel> CurrentRound = Model.Rounds.Where(x => x.First().MatchupRound == CurrentRoundNumber).First();
            foreach (var Matchup in CurrentRound)
            {
                foreach (var Mentry in Matchup.Entries)
                {
                    foreach (var Person in Mentry.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(Person, Mentry.TeamCompeting.TeamName, Matchup.Entries.Where(x => x.TeamCompeting != Mentry.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }
        private static void AlertPersonToNewRound(PersonModel person, string teamName, MatchupEntryModel? competitor)
        {
            if (person.EmailAddress.Length == 0)
            {
                return;    
            }

            string Subject = "", To = "";
            StringBuilder Body = new StringBuilder();

            if(competitor != null)
            {
                Subject = $"You have a new matchup with {competitor.TeamCompeting.TeamName}";
                Body.AppendLine("<h1>You have a new matchup</h1>");
                Body.Append("<strong>Competitor: </strong>");
                Body.Append(competitor.TeamCompeting.TeamName);
                Body.AppendLine();
                Body.AppendLine();
                Body.AppendLine("Have a great time!");
                Body.AppendLine(" - Fancu <3 ");

            }
            else
            {
                Subject = "You have a bye week this round";
                Body.AppendLine("Enjoy your round off!");
                Body.AppendLine(" - Fancu <3 ");
            }

            To = person.EmailAddress;

            EmailLogic.SendEmail(To, Subject, Body.ToString());
        }
        private static int CheckCurrentRound(this TournamentModel Model)
        {
            int Output = 1;
            
            foreach (List<MatchupModel> Round in Model.Rounds)
            {
                if (Round.All(x => x.Winner != null))
                {
                    Output++;        
                }
                else
                {
                    return Output;
                }
            }

            //Tournament is completed
            Model.CompleteTournament();
            return Output - 1;
        }

        private static void CompleteTournament(this TournamentModel Model)
        {
            GlobalConfig.Connection.CompleteTournament(Model);

            TeamModel? Winners = Model
                .Rounds
                .Last()
                .First().Winner;

            TeamModel RunnerUp = Model
                .Rounds
                .Last()
                .First()
                .Entries.Where(x => x.TeamCompeting != Winners)
                .First()
                .TeamCompeting;

            decimal WinnerPrize = 0, RunnerUpPrize = 0;
            
            if (Model.Prizes.Count > 0)
            {
                decimal TotalIncome = Model.EnteredTeams.Count * Model.EntryFee;

                PrizeModel? FirstPlacePrize = Model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel? SecondPlacePrize = Model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (FirstPlacePrize != null)
                {
                    WinnerPrize = FirstPlacePrize.CalculatePrizePayout(TotalIncome);
                }
                if (SecondPlacePrize != null)
                {
                    RunnerUpPrize = SecondPlacePrize.CalculatePrizePayout(TotalIncome);
                }
            }

            //Send Email to all Tournament
            string Subject = "";
            StringBuilder Body = new StringBuilder();

            Subject = $"In {Model.TournamentName}, {Winners.TeamName} has won!";
            Body.AppendLine("<h1>We have a Winner!</h1>");
            Body.AppendLine("<p>Congratulations to out winner on a great tournament</p>");
            Body.AppendLine("<br />");
            if (WinnerPrize > 0)
            {
                Body.AppendLine($"<p>{Winners.TeamName} will recieve ${WinnerPrize}</p>");
            }
            if (RunnerUpPrize > 0)
            {
                Body.AppendLine($"<p>{RunnerUp.TeamName} will recieve ${RunnerUpPrize}</p>");
            }
            Body.AppendLine("<p>Thanks for a grat tournament</p>");
            Body.AppendLine(" - Fancu <3 ");

            List<string> Bcc = new List<string>();

            foreach (var T in Model.EnteredTeams)
            {
                foreach (var P in T.TeamMembers)
                {
                    if (P.EmailAddress.Length > 0)
                    {
                        Bcc.Add(P.EmailAddress);
                    }
                }
            }
            EmailLogic.SendEmail(new List<string>(), Bcc, Subject, Body.ToString());

            Model.CompleteTournament();
        }
        private static decimal CalculatePrizePayout(this PrizeModel Prize, decimal TotalIncome)
        {
            decimal Output = 0;
            if (Prize.PrizeAmount > 0)
            {
                Output = Prize.PrizeAmount;
            }
            else
            {
                Output = decimal.Multiply(TotalIncome, Convert.ToDecimal(Prize.PrizePercentage / 100));
            }
            return Output;
        }

        private static void AdvanceWinners(List<MatchupModel> Models, TournamentModel Tournament)
        {
            foreach (MatchupModel M in Models)
            {
                foreach (List<MatchupModel> Round in Tournament.Rounds)
                {
                    foreach (MatchupModel Rm in Round)
                    {
                        foreach (MatchupEntryModel Me in Rm.Entries)
                        {
                            if (Me.ParentMatchup != null)
                            {
                                if (Me.ParentMatchup.Id == M.Id)
                                {
                                    Me.TeamCompeting = M.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(Rm);
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void MarkWinnerInMatchups(List<MatchupModel> Models)
        {
            if (ConfigurationManager.AppSettings["greaterWins"] == null)
            {
                return;
            }
            string GreaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (var M in Models)
            {
                //Cheeks for bye week entry
                if(M.Entries.Count == 1)
                {
                    M.Winner = M.Entries[0].TeamCompeting;
                    continue;
                }
                if (GreaterWins == "0")
                {
                    if (M.Entries[0].Score < M.Entries[1].Score)
                    {
                        M.Winner = M.Entries[0].TeamCompeting;
                    }
                    else if(M.Entries[1].Score < M.Entries[0].Score)
                    {
                        M.Winner = M.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("Ties are not allowed in this application");
                    }
                }
                else
                {
                    if (M.Entries[0].Score > M.Entries[1].Score)
                    {
                        M.Winner = M.Entries[0].TeamCompeting;
                    }
                    else if (M.Entries[1].Score > M.Entries[0].Score)
                    {
                        M.Winner = M.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("Ties are not allowed in this application");
                    }
                }
            }
        }
        private static void CreateOtherRounds(TournamentModel Model, int Rounds)
        {
            int Round = 2;
            List<MatchupModel> PreviousRound = Model.Rounds[0];
            List<MatchupModel> CurrentRound = new List<MatchupModel>();
            MatchupModel CurrentMatchup = new MatchupModel();


            while (Round <= Rounds)
            {
                foreach(MatchupModel Match in PreviousRound)
                {
                    CurrentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = Match });

                    if (CurrentMatchup.Entries.Count > 1)
                    {
                        CurrentMatchup.MatchupRound = Round;
                        CurrentRound.Add(CurrentMatchup);
                        CurrentMatchup = new MatchupModel();
                    }
                }

                Model.Rounds.Add(CurrentRound);
                
                PreviousRound = CurrentRound;
                
                CurrentRound = new List<MatchupModel>();
                
                Round += 1;
            }
        }
        private static List<MatchupModel> CreateFirstRound(int Byes, List<TeamModel> Teams)
        {
            List<MatchupModel> Output = new List<MatchupModel>();

            MatchupModel CurrentMatchup = new MatchupModel();

            foreach (TeamModel Team in Teams)
            {
                CurrentMatchup.Entries.Add(new MatchupEntryModel { TeamCompeting = Team });
                if (Byes > 0 || CurrentMatchup.Entries.Count > 1)
                {
                    CurrentMatchup.MatchupRound = 1;
                    
                    Output.Add(CurrentMatchup);

                    CurrentMatchup = new MatchupModel();

                    if (Byes > 0)
                    {
                        Byes -= 1;
                    }
                }
            }

            return Output;
        }
        private static int NumberOfByes(int Rounds, int NumberOfTeams)
        {
            int Output;
            int TotalTeams = 1;

            for (int i = 1; i <= Rounds; i++)
            {
                TotalTeams *= 2;    
            }

            Output = TotalTeams - NumberOfTeams;
            
            return Output;
        }
        private static int FindNumberOfRounds(int TeamCount)
        {
            int Output = 1, Val = 2;
            
            while(Val < TeamCount)
            {
                Output += 1;
                Val *= 2;
            }

            return Output;
        }
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> Teams)
        {
            return Teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
