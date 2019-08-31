using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alas
{
    class ApiRequest
    {
        public static string ApiKey { get; private set; }
        public static string ID { get; private set; }
        public static Dictionary<string, double> AllBalance { get; private set; }
        public static Dictionary<string, string> AllAddres { get; private set; }
        public static Dictionary<string, string> AllCursAndFee { get; private set; }
        public static string Login(string login, string password)
        {
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/login?login={login}&password={password}"));
            response = response.Trim('"');
            ApiKey = response.Split(' ')[0];
            ID = response.Split(' ')[1];
            Console.WriteLine("response = " + response);
            Console.WriteLine("ApiKey = "+ ApiKey);
            Console.WriteLine("ID = " + ID);
            return response;
        }
        public static string GetBalance(string apikey, string currency)
        {
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/getbalance?apikey={apikey}&currency={currency}&balanceM=1"));
            return response;
        }
        public static string Withdraw(string apikey, string addres, string type, double amount, double amount_rub, string currency, string wallet)
        {
            string amount_ = amount.ToString().Replace(',', '.');
            string amount_rub_ = amount_rub.ToString().Replace(',', '.');
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/withdraw?apikey={apikey}&addres={addres}&type={type}&amount={amount_}&amount_rub={amount_rub_}&currency={currency}&wallet={wallet}"));
            response = response.Trim('"');
            return response;
        }
        public static string CheckAddres(string apikey, string currency, string addres)
        {
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/getbalance?apikey={apikey}&currency={currency}&addres={addres}"));
            response = response.Trim('"');
            return response;
        }
        public static string Send(string apikey, string currency, string addres, double amount)
        {
            string amount_ = amount.ToString().Replace(',', '.');
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/sendbalance?apikey={apikey}&currency={currency}&addres={addres}&amount={amount_}"));
            response = response.Trim('"');
            return response;
        }
        public static string GetAddres(string apikey, string currency)
        {
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/getaddres?apikey={apikey}&currency={currency}&addresM=1"));
            return response;
        }
        public static string Register(string login, string password, string secretword)
        {
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/register?login={login}&password={password}&secretword={secretword}"));
            response = response.Trim('"');
            return response;
        }
        public static Dictionary<string, string> GetAllAddres()
        {
            string apikey = ApiKey;
            Dictionary<string, string> addres = new Dictionary<string, string>();
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/getalladdres?apikey={apikey}&alladdres=1"));
            addres = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            AllAddres = addres;
            //addres = response; парсим
            return addres;
        }
        public static Dictionary<string, string> GetAllCursAndFee()
        {
            string apikey = ApiKey;
            Dictionary<string, string> content = new Dictionary<string, string>();
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/GetAllCurseAndFee?apikey={apikey}&allcurse=1&allfee=1"));
            content = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            AllCursAndFee = content;
            //addres = response; парсим
            return content;
        }
        public static Dictionary<string, double> GetAllBalance()
        {
            string apikey = ApiKey;
            Dictionary<string, double> balance = new Dictionary<string, double>();
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/getbalance?apikey={apikey}&allbalance=1"));
            balance = JsonConvert.DeserializeObject<Dictionary<string, double>>(response);
            AllBalance = balance;
            //balance = response парсим
            return balance;
        }
        private static string GetResponse(string link)
        {
            using (StreamReader reader = new StreamReader(HttpWebRequest.Create(link).GetResponse().GetResponseStream()))
                return reader.ReadToEnd();
        }
        public static string Exchange(double amount, string currency1, string currency2)
        {
            string apikey = ApiKey;
            string amount_ = amount.ToString().Replace(',', '.');
            Console.WriteLine("currency1 = " + currency1 + " currency2 = " + currency2);
            string response = GetResponse(string.Format(AppSettings.ApiUrl,
                $"account/Exchange?apikey={apikey}&amount={amount_}&currency1={currency1}&currency2={currency2}"));
            response = response.Trim('"');
            return response;
        }
    }
}
