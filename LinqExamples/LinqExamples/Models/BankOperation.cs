using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.Models
{
    class BankOperation
    {
        public decimal Amount { get; set; }

        public decimal Rest { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string PersonCode { get; set; }
    }
}
