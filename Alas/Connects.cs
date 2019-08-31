using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alas
{
    public class Connects
    {
        public bool Exchange(string in_currency, string to_currency, decimal amount_in, decimal amount_to)
        {
            decimal your_balance = Convert.ToDecimal(ApiRequest.GetBalance(ApiRequest.ApiKey, in_currency).Replace('.', ','));
            Console.WriteLine("your_balance = " + your_balance + " amount_in = " + amount_in);
            if (your_balance >= amount_in)
            {
                ApiRequest.Exchange(Convert.ToDouble(amount_in), in_currency, to_currency);
                return true;
            }
            return false;
        }
    }
}
