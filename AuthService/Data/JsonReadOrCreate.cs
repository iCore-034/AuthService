using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AuthService
{
    internal class JsonReadOrCreate
    {
        private delegate void JsonReadOrCreateDelegate();
        JsonReadOrCreateDelegate readOrCreateDelegate;
        private void ReadData()
        {
            string str = File.ReadAllText(Data.jsonPath);
            Data.roles = JsonConvert.DeserializeObject<List<Roles>>(str);
        }
        private void CreateData()
        {
            List<Roles> roles = new List<Roles> {
                new Roles("admin", "admin"),
                new Roles("user", "user")};
            string json = JsonConvert.SerializeObject(roles);
            File.WriteAllText(Data.jsonPath, json);
        }
        public JsonReadOrCreate()
        {
            if (File.Exists(Data.jsonPath))
            {
                readOrCreateDelegate = ReadData;
                readOrCreateDelegate?.Invoke();
            }
            else
            {
                readOrCreateDelegate = CreateData;
                readOrCreateDelegate += ReadData;
                readOrCreateDelegate?.Invoke();
            }
        }
    }
}
