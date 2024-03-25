using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }
        public PrizeModel(string PlaceName, string PlaceNumber, string PrizeAmount, string PrizePercentage)
        {
            this.PlaceName = PlaceName;

            int PlaceNumberValue = 0;
            int.TryParse(PlaceNumber, out PlaceNumberValue);
            this.PlaceNumber = PlaceNumberValue;

            decimal PrizeAmountValue = 0;
            decimal.TryParse(PrizeAmount, out PrizeAmountValue);
            this.PrizeAmount = PrizeAmountValue;

            double PricePercentageValue = 0;
            double.TryParse(PrizePercentage, out PricePercentageValue);
            this.PrizePercentage = PricePercentageValue;
        }
    }
}
