using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    internal class JsonAdd
    {
        public JsonAdd(string login, string password)
        {
            Data.roles.Add(new Roles(login, password));
            string json = JsonConvert.SerializeObject(Data.roles);
            File.WriteAllText(Data.jsonPath, json);
        }
    }
}
