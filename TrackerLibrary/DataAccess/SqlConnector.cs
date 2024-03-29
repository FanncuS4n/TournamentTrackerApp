using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string Db = "Tournaments";

        public TeamModel CreateTeam(TeamModel model)
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
                    Team.Add("PersonId", Person.Id);

                    Connection.Execute("dbo.spTeamMembers_Insert", Team, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                var Person = new DynamicParameters();
                Person.Add("FirstName", model.FirstName);
                Person.Add("LastName", model.LastName);
                Person.Add("EmailAdress", model.EmailAdress);
                Person.Add("CellphoneNumber", model.CellphoneNumber);
                Person.Add("id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spPeople_Insert", Person, commandType: CommandType.StoredProcedure);

                model.Id = Person.Get<int>("@id");

                return model;
            }
        }

        /// <summary>
        /// Saves a new prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>Prize information, including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                var Prize  = new DynamicParameters();
                Prize.Add("PlaceNumber", model.PlaceNumber);
                Prize.Add("PlaceName", model.PlaceName);
                Prize.Add("PrizeAmount", model.PrizeAmount);
                Prize.Add("PrizePercentage", model.PrizePercentage);
                Prize.Add("id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spPrizes_Insert", Prize, commandType: CommandType.StoredProcedure);

                model.Id = Prize.Get<int>("@id");

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> Output;

            using(IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString(Db)))
            {
                //TODO: spPeople_GetAll was created on database but not tried!
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
    }
}
