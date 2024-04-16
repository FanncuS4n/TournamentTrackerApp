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
