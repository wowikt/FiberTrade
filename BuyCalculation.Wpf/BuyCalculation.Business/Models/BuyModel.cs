using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyCalculation.Business.Models
{
    public class BuyModel
    {
        public string GoodsName { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public double Cost => Price * Amount;
    }
}
