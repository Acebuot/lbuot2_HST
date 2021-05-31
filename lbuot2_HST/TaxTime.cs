using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lbuot2_HST
{
    class TaxTime
    {
        //hst – Total HST Billed
        public static decimal hst (decimal s)
        {
            return s * 0.13m;
        }

        //c – Amount of the extra credit on the first $30K
        public static decimal c(decimal s)
        {
            return (s > 30000m) ? 300.00m : (s * 0.01m);
        }

        //r – Total remittance you owe the government
        public static decimal r(decimal s, decimal c)
        {
            return (s * 0.088m) + c;
        }
        //k – The amount you get to keep
        public static decimal k(decimal hst, decimal r)
        {
            return hst - r;
        }

        public static decimal installment(decimal r, decimal months)
        {
            return r / months;
        }


    }
}
