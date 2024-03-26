using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
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
                
                PrizeModel Prize = new PrizeModel();
                Prize.Id = int.Parse(Cols[0]);
                Prize.PlaceNumber = int.Parse(Cols[1]);
                Prize.PlaceName = Cols[2];
                Prize.PrizeAmount = decimal.Parse(Cols[3]);
                Prize.PrizePercentage = double.Parse(Cols[4]);
                Output.Add(Prize);
            }

            return Output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> Lines)
        {
            List<PersonModel> Output = new List<PersonModel>();
            
            foreach (string Line in Lines)
            {
                string[] Cols = Line.Split(",");

                PersonModel Person = new PersonModel();
                Person.Id = int.Parse(Cols[0]);
                Person.FirstName = Cols[1];
                Person.LastName = Cols[2];
                Person.EmailAdress = Cols[3];
                Person.CellphoneNumber = Cols[4];

                Output.Add(Person);
            }

            return Output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> Models, string FileName)
        {
            List<string> Lines = new List<string>();
            foreach (PrizeModel Prize in Models)
            {
                Lines.Add($"{Prize.Id},{Prize.PlaceNumber},{Prize.PlaceName},{Prize.PrizeAmount},{Prize.PrizePercentage}");          
            }
            File.WriteAllLines(FileName.FullFilePath(), Lines);
        }
        public static void SaveToPersonFile(this List<PersonModel> Models, string FileName)
        {
            List<string> Lines = new List<string>();
            foreach (PersonModel Person in Models)
            {
                Lines.Add($"{Person.Id},{Person.FirstName},{Person.LastName},{Person.EmailAdress}, {Person.CellphoneNumber}");
            }

            File.WriteAllLines(FileName.FullFilePath(), Lines);
        }

    }
}
