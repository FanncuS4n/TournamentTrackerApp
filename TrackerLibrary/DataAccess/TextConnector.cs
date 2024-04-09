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
        private const string _PrizesFile = "PrizeModels.csv";
        private const string _PersonFile = "PersonModels.csv";
        private const string _TeamFile = "TeamModels.csv";
        private const string _TournamentFile = "TournamentModel.csv";
        private const string _MatchupFile = "MatchupModels.csv";
        private const string _MatchupEntryFile = "MatchupEntryModels.csv";


        public PrizeModel CreatePrize(PrizeModel Model)
        {
            // Load the textfile & Convert the text to a list
            List<PrizeModel> Prizes = _PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

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
            Prizes.SaveToPrizeFile(_PrizesFile);

            return Model;
        }

        public PersonModel CreatePerson(PersonModel Model)
        {
            List<PersonModel> Person = _PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int CurrentId = 0;
            if (Person.Count > 0)
            {
                CurrentId = Person.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Model.Id = CurrentId;
            Person.Add(Model);
            Person.SaveToPersonFile(_PersonFile);
            return Model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return _PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel Model)
        {
            List<TeamModel> Teams = _TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(_PersonFile);

            int CurrentId = 1;

            if (Teams.Count > 0)
            {
                CurrentId = Teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            Model.Id = CurrentId;

            Teams.Add(Model);

            Teams.SaveToTeamFile(_TeamFile);

            return Model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return _TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(_PersonFile);
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> Tournaments = _TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels(_TeamFile, _PersonFile, _PrizesFile);

            int CurrentId = 1;

            if (Tournaments.Count > 0)
            {
                CurrentId = Tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = CurrentId;

            model.SaveRoundsToFile(_MatchupFile, _MatchupEntryFile);

            Tournaments.Add(model);

            Tournaments.SaveToTournamentFile(_TournamentFile);
        }
    }
}
