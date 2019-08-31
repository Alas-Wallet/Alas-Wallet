using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alas
{
    class Calculate
    {
        public decimal Converter(decimal AMOUNT, decimal CURS_IN, decimal CURS_OUT)
        {
            if (AMOUNT != 0)
            {
                decimal result = AMOUNT * CURS_IN / CURS_OUT;
                return result;
            }
            return 0;
        }
    }
}
