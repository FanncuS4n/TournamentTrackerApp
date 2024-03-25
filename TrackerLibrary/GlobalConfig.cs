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
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static void InitializeConnections (bool Database, bool TextFiles)
        {
            if (Database)
            {
                //TODO: SQL Connection
                SqlConnector sql = new SqlConnector ();
                Connections.Add(sql);
            }
            if (TextFiles)
            {
                //TODO: Text Connection
                TextConnector text = new TextConnector ();
                Connections.Add(text);
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
