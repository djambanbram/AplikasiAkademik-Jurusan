using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService
{
    public class LoginAccess
    {
        public static string username { get; set; }
        public static string access_token { get; set; }
        public static string token_type { get; set; }
        public static string expires_in { get; set; }
    }
}
