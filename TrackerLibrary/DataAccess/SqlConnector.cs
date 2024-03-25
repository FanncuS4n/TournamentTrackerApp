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
        /// <summary>
        /// Saves a new prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>Prize information, including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString("Tournaments")))
            {
                var p  = new DynamicParameters();
                p.Add("PlaceNumber", model.PlaceNumber);
                p.Add("PlaceName", model.PlaceName);
                p.Add("PrizeAmount", model.PrizeAmount);
                p.Add("PrizePercentage", model.PrizePercentage);
                p.Add("id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
}
