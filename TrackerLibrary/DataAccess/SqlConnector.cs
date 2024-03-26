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
        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString("Tournaments")))
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
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString("Tournaments")))
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
    }
}
