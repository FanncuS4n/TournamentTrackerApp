using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string FileName) // FileName example: PrizeModels.csv
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ FileName }";
            // This translates into: filePath\FileName.csv
        }
        public static List<string> LoadFile(this string FileName)
        {
            if (!File.Exists(FileName))
            {
                return new List<string>();
            }

            return File.ReadAllLines(FileName).ToList();
        }
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> Lines)
        {
            List<PrizeModel> Output = new List<PrizeModel>();

            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(',');
                
                PrizeModel Prize = new PrizeModel();
                Prize.Id = int.Parse(Cols[0]);
                Prize.PlaceNumber = int.Parse(Cols[1]);
                Prize.PlaceName = Cols[2];
                Prize.PrizeAmount = decimal.Parse(Cols[3]);
                Prize.PrizePercentage = double.Parse(Cols[4]);
                Output.Add(Prize);
            }

            return Output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> Lines)
        {
            List<PersonModel> Output = new List<PersonModel>();
            
            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(",");

                PersonModel Person = new PersonModel();
                Person.Id = int.Parse(Cols[0]);
                Person.FirstName = Cols[1];
                Person.LastName = Cols[2];
                Person.EmailAddress = Cols[3];
                Person.CellphoneNumber = Cols[4];

                Output.Add(Person);
            }

            return Output;
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> Lines)
        {
            //Id, TeamName, List of Ids separated by |

            List<TeamModel> Output = new List<TeamModel>();

            List<PersonModel> People = GlobalConfig._PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(",");

                TeamModel Team = new TeamModel();
                Team.Id = int.Parse(Cols[0]);
                Team.TeamName = Cols[1];

                string[] PersonIds = Cols[2].Split("|");

                foreach (string Id in PersonIds)
                {
                    Team.TeamMembers.Add(People.Where(x => x.Id == int.Parse(Id)).First());
                }
                Output.Add(Team);
            }
            return Output;
        }
        public static List<TournamentModel>ConvertToTournamentModels(this List<string> Lines)
        {
            //Final result example:
            //id, -> Col 0
            //TournamentName,-> Col 1
            //EntryFee,-> Col 2
            //(id|id|id) = Entered teams, -> Col 3
            //(id|id|id) = Prizes, -> Col 4
            //(id*id*id|id*id*id|id*id*id) = Rounds / Matchup models -> Col 5

            List<TournamentModel> Output = new List<TournamentModel>();

            List<TeamModel> Teams = GlobalConfig._TeamFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTeamModels();

            List<PrizeModel> Prizes = GlobalConfig._PrizesFile
                .FullFilePath()
                .LoadFile()
                .ConvertToPrizeModels();
            List<MatchupModel> Matchups = GlobalConfig._MatchupFile
                .FullFilePath()
                .LoadFile()
                .ConvertToMatchupModels();

            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(',');
                TournamentModel TournamentModel = new TournamentModel();
                TournamentModel.Id = int.Parse(Cols[0]);
                TournamentModel.TournamentName = Cols[1];
                TournamentModel.EntryFee = decimal.Parse(Cols[2]);

                string[] TeamIds = Cols[3].Split("|");
                foreach (string Id in TeamIds)
                {
                    TournamentModel.EnteredTeams.Add(Teams.Where(x => x.Id == int.Parse(Id)).First());
                }

                if (Cols[4].Length > 0)
                {
                    string[] PrizeIds = Cols[4].Split("|");
                    foreach (string Id in PrizeIds)
                    {
                        TournamentModel.Prizes.Add(Prizes.Where(x => x.Id == int.Parse(Id)).First());
                    }
                }

                //Captures Rounds information
                string[] Rounds = Cols[5].Split("|");
                foreach (string Round in Rounds)
                {
                    string[] MsText = Round.Split("*");
                    List<MatchupModel> Ms = new List<MatchupModel>();

                    foreach (string MatchupModelTextId in MsText)
                    {
                        Ms.Add(Matchups.Where(x => x.Id == int.Parse(MatchupModelTextId)).First());
                    }
                    TournamentModel.Rounds.Add(Ms);
                }

                Output.Add(TournamentModel);
            }

            return Output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> Models)
        {
            List<string> Lines = new List<string>();
            foreach (PrizeModel Prize in Models)
            {
                Lines.Add($"{Prize.Id},{Prize.PlaceNumber},{Prize.PlaceName},{Prize.PrizeAmount},{Prize.PrizePercentage}");          
            }
            File.WriteAllLines(GlobalConfig._PrizesFile.FullFilePath(), Lines);
        }
        public static void SaveToPersonFile(this List<PersonModel> Models)
        {
            List<string> Lines = new List<string>();
            foreach (PersonModel Person in Models)
            {
                Lines.Add($"{Person.Id},{Person.FirstName},{Person.LastName},{Person.EmailAddress}, {Person.CellphoneNumber}");
            }

            File.WriteAllLines(GlobalConfig._PersonFile.FullFilePath(), Lines);
        }
        public static void SaveToTeamFile(this List<TeamModel> Models)
        {
            List<string> Lines = new List<string>();
            foreach (var Team in Models)
            {
                Lines.Add($"{Team.Id}, {Team.TeamName}, {ConvertPeopleListToString(Team.TeamMembers)}");
            }

            File.WriteAllLines(GlobalConfig._TeamFile.FullFilePath(), Lines);
        }
        public static void SaveRoundsToFile(this TournamentModel Model)
        {
            //Loop through each Round
            //Loop through each Matchup
            //Get the id for the new matchup and save the record
            //Loop through each entry, get the id and save it

            foreach (var Round in Model.Rounds)
            {
                foreach (var Matchup in Round)
                {
                    //Load all ofthe matchups from file
                    //Get the top id and add one
                    //Store the id
                    //Save the matchup record
                    
                    Matchup.SaveMatchupToFile(); 
                }
            }
        }
        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> Lines)
        {
            List<MatchupEntryModel> Output = new List<MatchupEntryModel>();
            
            foreach (var Line in Lines)
            {
                string[] Cols = Line.Split(',');

                var MatchupEntry = new MatchupEntryModel();
                MatchupEntry.Id = int.Parse(Cols[0]);
                if (Cols[1].Length == 0)
                {
                    MatchupEntry.TeamCompeting = null;
                }
                else
                {
                    MatchupEntry.TeamCompeting = LookupTeamById(int.Parse(Cols[1]));
                }
                MatchupEntry.Score = double.Parse(Cols[2]);

                int ParentId;
                if (int.TryParse(Cols[3], out ParentId))
                {
                    MatchupEntry.ParentMatchup = LookUpMatchupById(ParentId);
                }
                else
                {
                    MatchupEntry.ParentMatchup = null;
                }
                Output.Add(MatchupEntry);
            }

            return Output;
        }
        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string Input)
        {
            string[] Ids = Input.Split('|');
            var Output = new List<MatchupEntryModel>();
            List<string> Entries = GlobalConfig._MatchupEntryFile.FullFilePath().LoadFile();
            var MatchingEntries = new List<string>();
            foreach (string Id in Ids)
            {
                foreach (string Entry in Entries)
                {
                    string[] Cols = Entry.Split(',');

                    if (Cols[0] == Id)
                    {
                        MatchingEntries.Add(Entry);
                    }
                }
            }
            Output = MatchingEntries.ConvertToMatchupEntryModels();

            return Output;
        }
        private static TeamModel LookupTeamById(int Id)
        {
            List<string> Teams = GlobalConfig._TeamFile.FullFilePath().LoadFile();

            foreach (var Team in Teams)
            {
                string[] Cols = Team.Split(',');
                if (Cols[0] == Id.ToString())
                {
                    List<string> MatchingTeams = new List<string>();
                    
                    MatchingTeams.Add(Team);

                    return MatchingTeams.ConvertToTeamModels().First();
                }
            }
            //No team found
            return null;
        }
        private static MatchupModel? LookUpMatchupById(int Id)
        {
            List<string> Matchups = GlobalConfig._MatchupFile.FullFilePath().LoadFile();
            
            foreach(string Matchup in Matchups)
            {
                string[] Cols = Matchup.Split(',');
                if (Cols[0] == Id.ToString())
                {
                    var MatchingMatchups = new List<String>();
                    MatchingMatchups.Add(Matchup);
                    return MatchingMatchups.ConvertToMatchupModels().First();
                }
            }
         
            return null;
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> Lines)
        {
            //Id = 0, Entries = 1(pipe dilimited by id), winner = 2, MatchupRound = 3

            List<MatchupModel> Output = new List<MatchupModel>();

            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(',');

                MatchupModel Matchup = new MatchupModel();
                Matchup.Id = int.Parse(Cols[0]);
                Matchup.Entries = ConvertStringToMatchupEntryModels(Cols[1]);

                if (Cols[2].Length == 0)
                {
                    Matchup.Winner = null;
                }
                else
                {
                    Matchup.Winner = LookupTeamById(int.Parse(Cols[2]));
                }

                Matchup.MatchupRound = int.Parse(Cols[3]);

                Output.Add(Matchup);
            }

            return Output;
        }
        public static void SaveMatchupToFile(this MatchupModel Matchup)
        {
            List<MatchupModel> Matchups = GlobalConfig._MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int CurrentId = 1;

            if (Matchups.Count > 0)
            {
                CurrentId = Matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Matchup.Id = CurrentId;

            foreach (MatchupEntryModel Entry in Matchup.Entries)
            {
                Entry.SaveEntryToFile();
            }

            //Save to file
            var Lines = new List<string>();
            foreach (MatchupModel M in Matchups)
            {
                string Winner = "";
                if (M.Winner != null)
                {
                    Winner = M.Winner.Id.ToString();
                }
                Lines.Add($"{M.Id},{ConvertMatchupEntryListToString(M.Entries)},{Winner},{M.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig._MatchupFile.FullFilePath(), Lines);
        }
        public static void UpdateMatchupToFile(this MatchupModel Matchup)
        {
            List<MatchupModel> Matchups = GlobalConfig._MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            MatchupModel OldMatchup = new MatchupModel();
            foreach (MatchupModel M in Matchups)
            {
                if (M.Id == Matchup.Id)
                {
                    OldMatchup = M;
                }
            }
            Matchups.Remove(OldMatchup);

            Matchups.Add(Matchup);

            foreach (MatchupEntryModel Entry in Matchup.Entries)
            {
                Entry.UpdateEntryToFile();
            }

            //Save to file
            var Lines = new List<string>();
            foreach (MatchupModel M in Matchups)
            {
                string Winner = "";
                if (M.Winner != null)
                {
                    Winner = M.Winner.Id.ToString();
                }
                Lines.Add($"{M.Id},{ConvertMatchupEntryListToString(M.Entries)},{Winner},{M.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig._MatchupFile.FullFilePath(), Lines);

        }
        public static void UpdateEntryToFile(this MatchupEntryModel Entry)
        {
            List<MatchupEntryModel> Entries = GlobalConfig._MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            MatchupEntryModel OldEntry = new MatchupEntryModel();

            foreach (var E in Entries)
            {
                if (E.Id == Entry.Id)
                {
                    OldEntry = E;
                }
            }
            Entries.Remove(OldEntry);

            Entries.Add(Entry);

            List<string> Lines = new List<string>();

            foreach (var E in Entries)
            {
                string Parent = "";
                if (E.ParentMatchup != null)
                {
                    Parent = E.ParentMatchup.Id.ToString();
                }

                string TeamCompeting = "";
                if (E.TeamCompeting != null)
                {
                    TeamCompeting = E.TeamCompeting.Id.ToString();
                }

                Lines.Add($"{E.Id},{TeamCompeting},{E.Score},{Parent}");
            }
            File.WriteAllLines(GlobalConfig._MatchupEntryFile.FullFilePath(), Lines);
        }
        public static void SaveEntryToFile(this MatchupEntryModel Entry)
        {
            List<MatchupEntryModel> Entries = GlobalConfig._MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            
            int CurrentId = 1;
            
            if (Entries.Count > 0)
            {
                CurrentId = Entries.OrderByDescending(x => x.Id).First().Id + 1;
            
            }
            Entry.Id = CurrentId;

            Entries.Add(Entry);

            //Save to file
            List<string> Lines = new List<string>();
            foreach (var E in Entries)
            {
                string Parent = "";
                if (E.ParentMatchup != null)
                {
                    Parent = E.ParentMatchup.Id.ToString();
                }

                string TeamCompeting = "";
                if (E.TeamCompeting != null)
                {
                    TeamCompeting = E.TeamCompeting.Id.ToString();
                }

                Lines.Add($"{E.Id},{TeamCompeting},{E.Score},{Parent}");
            }
            File.WriteAllLines(GlobalConfig._MatchupEntryFile.FullFilePath(), Lines);
        }
        public static void SaveToTournamentFile(this List<TournamentModel> Models)
        {
            List<string> Lines = new List<string>();

            foreach (var Tm in Models)
            {
                Lines.Add($"{ Tm.Id },{ Tm.TournamentName },{ Tm.EntryFee },{ ConvertTeamListToString(Tm.EnteredTeams) },{ ConvertPrizeListToString(Tm.Prizes) },{ ConvertRoundListToString(Tm.Rounds) }");
            }

            File.WriteAllLines(GlobalConfig._TournamentFile.FullFilePath(), Lines);
        }
        private static string ConvertPeopleListToString(List<PersonModel> Person)
        {
            string Output = "";

            //Ids = 2,5,1
            if (Person.Count == 0)
            {
                return Output;
            }

            foreach (PersonModel P in Person)
            {
                Output += $"{P.Id}|";
            }
            //Output value: 2|5|1|

            Output = Output.Substring(0, Output.Length - 1);
            //Output value: 2|5|1
            
            return Output;
        }
        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> Entries)
        {
            string Output = "";

            if (Entries.Count == 0)
            {
                return Output;
            }

            foreach (MatchupEntryModel E in Entries)
            {
                Output += $"{E.Id}|";
            }

            Output = Output.Substring(0, Output.Length - 1);

            return Output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> Prize)
        {
            string Output = "";

            if (Prize.Count == 0)
            {
                return Output;
            }

            foreach (PrizeModel P in Prize)
            {
                Output += $"{P.Id}|";
            }

            Output = Output.Substring(0, Output.Length - 1);

            return Output;
        }
        private static string ConvertTeamListToString(List<TeamModel> Teams)
        {
            string Output = "";

            if (Teams.Count == 0)
            {
                return Output;
            }

            foreach (TeamModel T in Teams)
            {
                Output += $"{T.Id}|";
            }

            Output = Output.Substring(0, Output.Length - 1);

            return Output;
        }
        private static string ConvertRoundListToString(List<List<MatchupModel>> Rounds)
        {
            string Output = "";

            if (Rounds.Count == 0)
            {
                return Output;
            }

            foreach (List<MatchupModel> R in Rounds)
            {
                Output += $"{ ConvertMatchupListToString(R) }|";
            }

            Output = Output.Substring(0, Output.Length - 1);

            return Output;
        }
        private static string ConvertMatchupListToString(List<MatchupModel> Matchups)
        {
            string Output = "";

            if (Matchups.Count == 0)
            {
                return Output;
            }

            foreach (MatchupModel M in Matchups)
            {
                Output += $"{M.Id}*";
            }

            Output = Output.Substring(0, Output.Length - 1);

            return Output;
        }
    }
}
