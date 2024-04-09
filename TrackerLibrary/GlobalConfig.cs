using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string _PrizesFile = "PrizeModels.csv";
        public const string _PersonFile = "PersonModels.csv";
        public const string _TeamFile = "TeamModels.csv";
        public const string _TournamentFile = "TournamentModel.csv";
        public const string _MatchupFile = "MatchupModels.csv";
        public const string _MatchupEntryFile = "MatchupEntryModels.csv";

        public static IDataConnection Connection { get; private set; }
        public static void InitializeConnections (DatabaseType ConnectionType)
        {
            switch (ConnectionType)
            {
                case DatabaseType.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseType.TextFile:
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the connection string
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>Connection String</returns>
        public static string ConectionString(string Name)
        {
            return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }
    }
}
