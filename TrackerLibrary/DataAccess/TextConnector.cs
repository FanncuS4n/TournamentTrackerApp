using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Reflection;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public void CreatePrize(PrizeModel Model)   
        {
            // Load the textfile & Convert the text to a list
            List<PrizeModel> Prizes = GlobalConfig._PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int CurrentId = 1;

            if (Prizes.Count > 0)
            {
                CurrentId = Prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Model.Id = CurrentId;

            // Add the new record with the new ID (max + 1)
            Prizes.Add(Model);

            // Convert the prizes to a list of strings & Save the list of strings to the text file
            Prizes.SaveToPrizeFile();
        }
        public void CreatePerson(PersonModel Model)
        {
            List<PersonModel> Person = GlobalConfig._PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int CurrentId = 0;
            if (Person.Count > 0)
            {
                CurrentId = Person.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Model.Id = CurrentId;
            Person.Add(Model);
            Person.SaveToPersonFile();
        }
        public void CreateTeam(TeamModel Model)
        {
            List<TeamModel> Teams = GlobalConfig._TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int CurrentId = 1;

            if (Teams.Count > 0)
            {
                CurrentId = Teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Model.Id = CurrentId;

            Teams.Add(Model);

            Teams.SaveToTeamFile();
        }
        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> Tournaments = GlobalConfig._TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();

            int CurrentId = 1;

            if (Tournaments.Count > 0)
            {
                CurrentId = Tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = CurrentId;

            model.SaveRoundsToFile();

            Tournaments.Add(model);

            Tournaments.SaveToTournamentFile();

            TournamentLogic.TournamentLogic.UpdateTournamentResults(model);
        }
        public void UpdateMatchup(MatchupModel Model)
        {
            Model.UpdateMatchupToFile();
        }
        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig._PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }
        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig._TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }
        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig._TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();
        }

    }
}
