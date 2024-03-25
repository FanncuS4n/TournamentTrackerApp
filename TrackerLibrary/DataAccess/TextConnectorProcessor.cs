using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string FileName) // FileName example: PrizeModels.csv
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ FileName }";
            // This translates into: filePath\FileName.csv
        }
        public static List<string> LoadFile(this string FileName)
        {
            if (!File.Exists(FileName))
            {
                return new List<string>();
            }

            return File.ReadAllLines(FileName).ToList();
        }
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> Lines)
        {
            List<PrizeModel> Output = new List<PrizeModel>();

            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(',');
                
                PrizeModel P = new PrizeModel();
                P.Id = int.Parse(Cols[0]);
                P.PlaceNumber = int.Parse(Cols[1]);
                P.PlaceName = Cols[2];
                P.PrizeAmount = decimal.Parse(Cols[3]);
                P.PrizePercentage = double.Parse(Cols[4]);
                Output.Add(P);
            }

            return Output;
        }
    }
}
