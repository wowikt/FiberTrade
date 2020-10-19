using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyCalculation.Business.Models
{
    public class BuyListModel
    {
        public List<BuyModel> BuyList { get; } = new List<BuyModel>();

        public double TotalCost => BuyList.Sum(buy => buy.Cost);
    }
}
