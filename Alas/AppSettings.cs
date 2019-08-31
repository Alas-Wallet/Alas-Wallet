using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alas
{
    class AppSettings
    {
        public static string ApiUrl { get; } = "http://evermoon-001-site1.itempurl.com/api/{0}";
        public static int UpdateTime { get; } = 300000; // 5 минут
    }
}
