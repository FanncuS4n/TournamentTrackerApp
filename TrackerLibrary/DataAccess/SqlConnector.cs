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
            throw new NotImplementedException();

            using (IDbConnection Connection = new SqlConnection(GlobalConfig.ConectionString("Tournaments")))
            {
                
            }
        }
    }
}
