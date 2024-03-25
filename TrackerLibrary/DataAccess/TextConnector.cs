using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the textfile
            // Convert the text to a list
            // Find the max ID
            // Add the new record with the new ID (max + 1)
            // Convert the prizes to a list of strings
            // Save the list of strings to the text file
            throw new NotImplementedException();
        }
    }
}
