using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuthService
{
    internal class Data
    {
        public static List<string> tables = new List<string>() { 
            "Order", 
            "Service", 
            "Car", 
            "Client", 
            "Employee", 
            "Position"
        };
        public static string jsonPath = "roles.json";
        public static bool AuthSuccess = true;
        public static List<Roles> roles = null;
        public static bool adminRights { get; set; }

        public static string choosedTable { get; set; }

        public static List<Client>   clients   = new List<Client>();
        public static List<Service>  services  = new List<Service>();
        public static List<Order>    orders    = new List<Order>();
        public static List<Position> positions = new List<Position>();
        public static List<Car>      cars      = new List<Car>();
        public static List<Employee> employees = new List<Employee>();

        public static string attentionBox = "Something goes wrong..";
        public static string attention    = "Attention!";
    }
}
