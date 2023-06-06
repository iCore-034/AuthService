using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    internal class Roles
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
