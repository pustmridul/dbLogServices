using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices
{
    public static class GlobalClass
    {
        public static string VATPer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["VATPer"];
        public static string SDPer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["SDPer"];
        public static string URL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["APIURL"];
        public static string APIUserName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["APIUserName"];
        public static string APIPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["APIPassword"];
        public static string CustomerCode = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["CustomerCode"];
        public static string CustomerMobile = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["CustomerMobile"];
        public static string ShopID = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["ShopID"];
        public static string Token = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["Token"];
        public static string StorecodeWithoutEcomm = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["storecodeWithoutEcomm"];
    }
}
