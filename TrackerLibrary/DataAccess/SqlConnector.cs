using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.TournamentLogic;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string Db = "Tournaments";

        public void CreateTeam(TeamModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                var Team = new DynamicParameters();
                Team.Add("@TeamName", model.TeamName);
                Team.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spTeams_Insert", Team, commandType: CommandType.StoredProcedure);

                model.Id = Team.Get<int>("@id");

                foreach (PersonModel Person in model.TeamMembers)
                {
                    Team = new DynamicParameters();
                    Team.Add("@TeamId", model.Id);
                    Team.Add("@PersonId", Person.Id);

                    Connection.Execute("dbo.spTeamMembers_Insert", Team, commandType: CommandType.StoredProcedure);
                }
            }
        }
        public void CreatePerson(PersonModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                var Person = new DynamicParameters();
                Person.Add("@FirstName", model.FirstName);
                Person.Add("@LastName", model.LastName);
                Person.Add("@EmailAddress", model.EmailAddress);
                Person.Add("@CellphoneNumber", model.CellphoneNumber);
                Person.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spPeople_Insert", Person, commandType: CommandType.StoredProcedure);

                model.Id = Person.Get<int>("@id");
            }
        }
        public void CreatePrize(PrizeModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                var Prize  = new DynamicParameters();
                Prize.Add("@PlaceNumber", model.PlaceNumber);
                Prize.Add("@PlaceName", model.PlaceName);
                Prize.Add("@PrizeAmount", model.PrizeAmount);
                Prize.Add("@PrizePercentage", model.PrizePercentage);
                Prize.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spPrizes_Insert", Prize, commandType: CommandType.StoredProcedure);

                model.Id = Prize.Get<int>("@id");

            }
        }
        public void CreateTournament(TournamentModel Model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                SaveTournament(Connection,Model);
                SaveTournamentPrizes(Connection, Model);
                SaveTournamentEntries(Connection, Model);
                SaveTournamentRounds(Connection, Model);
                TournamentLogic.TournamentLogic.UpdateTournamentResults(Model);
            }
        }

        private void SaveTournament(IDbConnection Connection, TournamentModel Model)
        {
            var Tournament = new DynamicParameters();
            Tournament.Add("@TournamentName", Model.TournamentName);
            Tournament.Add("@EntryFee", Model.EntryFee);
            Tournament.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            Connection.Execute("dbo.spTournaments_Insert", Tournament, commandType: CommandType.StoredProcedure);

            Model.Id = Tournament.Get<int>("@id");
        }
        private void SaveTournamentRounds(IDbConnection Connection, TournamentModel Model)
        {
            //Loop through the rounds
            foreach (List<MatchupModel> Round in Model.Rounds)
            {
                //Loop through the matchups
                foreach (MatchupModel Matchup in Round)
                {
                    var M = new DynamicParameters();
                    M.Add("@TournamentId", Model.Id);
                    M.Add("@MatchupRound", Matchup.MatchupRound);
                    M.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    
                    //Save the matchup 
                    Connection.Execute("dbo.spMatchups_Insert", M, commandType: CommandType.StoredProcedure);
                    
                    Matchup.Id = M.Get<int>("@id");

                    //Loop through the entries and save them
                    foreach (var Entry in Matchup.Entries)
                    {
                        M = new DynamicParameters();
                        M.Add("@MatchupId", Matchup.Id);

                        if (Entry.ParentMatchup == null)
                        {
                            M.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            M.Add("@ParentMatchupId", Entry.ParentMatchup.Id);
                        }

                        if (Entry.TeamCompeting == null)
                        {
                            M.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            M.Add("@TeamCompetingId", Entry.TeamCompeting.Id);
                        }

                        M.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        Connection.Execute("dbo.spMatchupEntries_Insert", M, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }
        private void SaveTournamentEntries(IDbConnection Connection, TournamentModel Model)
        {
            foreach (TeamModel Team in Model.EnteredTeams)
            {
                var Tournament = new DynamicParameters();
                Tournament.Add("@TournamentId", Model.Id);
                Tournament.Add("@TeamId", Team.Id);
                Tournament.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spTournamentEntries_Insert", Tournament, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentPrizes(IDbConnection Connection, TournamentModel Model)
        {
            foreach (PrizeModel Prize in Model.Prizes)
            {
                var Tournament = new DynamicParameters();
                Tournament.Add("@TournamentId", Model.Id);
                Tournament.Add("@PrizeId", Prize.Id);
                Tournament.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spTournamentPrizes_Insert", Tournament, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateMatchup(MatchupModel Model)
        {
            using (IDbConnection Connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                //Store the matchup
                var Matchup = new DynamicParameters();
                if (Model.Winner != null) 
                {
                    Matchup.Add("@id", Model.Id);
                    Matchup.Add("@WinnerId", Model.Winner.Id);
                }

                Connection.Execute("dbo.spMatchups_Update", Matchup, commandType: CommandType.StoredProcedure);

                //Store the entries
                foreach (MatchupEntryModel Entry in Model.Entries)
                {
                    if (Entry.TeamCompeting != null)
                    {
                        var parameter = new DynamicParameters();
                        parameter.Add("@id", Entry.Id);
                        parameter.Add("@TeamCompetingId", Entry.TeamCompeting.Id);
                        parameter.Add("@Score", Entry.Score);

                        Connection.Execute("dbo.spMatchupEntries_Update", parameter, commandType: CommandType.StoredProcedure);

                    }
                }
            }
        }
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> Output;

            using(IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                Output = Connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return Output;
        }
        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> Output;

            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                Output = Connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel Team in Output)
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@TeamId", Team.Id);

                    Team.TeamMembers = Connection.Query<PersonModel>(
                        "dbo.spTeamMembers_GetByTeam", 
                        Parameters, 
                        commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return Output;
        }
        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel > Output;
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                Output = Connection.Query<TournamentModel>("dbo.spTournaments_GetAll").ToList();
                var parameter = new DynamicParameters();

                foreach (TournamentModel T in Output)
                {
                    //Fill prizes
                    parameter = new DynamicParameters();
                    parameter.Add("TournamentId", T.Id);
                    T.Prizes = Connection.Query<PrizeModel>("dbo.spPrizes_GetByTournament", parameter, commandType: CommandType.StoredProcedure).ToList();

                    //Fill teams
                    parameter = new DynamicParameters();
                    parameter.Add("TournamentId", T.Id);
                    T.EnteredTeams = Connection.Query<TeamModel>("dbo.spTeam_GetByTournamment", parameter, commandType: CommandType.StoredProcedure).ToList();
                    
                    foreach (TeamModel Team in T.EnteredTeams)
                    {
                        parameter = new DynamicParameters();
                        parameter.Add("@TeamId", Team.Id);

                        Team.TeamMembers = Connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", parameter, commandType: CommandType.StoredProcedure).ToList();
                    }

                    //Fill Rounds
                    parameter = new DynamicParameters();
                    parameter.Add("@TournamentId", T.Id);

                    List<MatchupModel> Matchups = Connection.Query<MatchupModel>("dbo.spMatchups_GetByTournament", parameter, commandType: CommandType.StoredProcedure).ToList();

                    foreach (MatchupModel m in Matchups)
                    {
                        parameter = new DynamicParameters();
                        parameter.Add("@MatchupId", m.Id);
                        m.Entries= Connection.Query<MatchupEntryModel>("dbo.spMatchupEntries_GetByMatchup", parameter, commandType: CommandType.StoredProcedure).ToList();

                        // Populate each entry (2 models)
                        // Populate each matchup (1 model)
                        List<TeamModel> AllTeams = GetTeam_All();

                        if (m.WinnerId > 0)
                        {
                            m.Winner = AllTeams.Where(x => x.Id == m.WinnerId).First();
                        }

                        foreach (MatchupEntryModel me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.TeamCompeting = AllTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }
                            if (me.ParentMatchup.Id > 0)
                            {
                                me.ParentMatchup = Matchups.Where(x => x.Id == me.ParentMatchupId).First();
                            }
                        }
                    }
                    //Populate the List<List<MatchupModels>>
                    List<MatchupModel> CurrentRow = new List<MatchupModel>();
                    int CurrentRound = 1;
                    foreach (MatchupModel M in Matchups)
                    {
                        if (M.MatchupRound > CurrentRound)
                        {
                            T.Rounds.Add(CurrentRow);
                            CurrentRow = new List<MatchupModel>();
                            CurrentRound += 1;
                        }
                        CurrentRow.Add(M);
                    }
                    T.Rounds.Add(CurrentRow);
                }
            }
            return Output;
        }
    }
}
