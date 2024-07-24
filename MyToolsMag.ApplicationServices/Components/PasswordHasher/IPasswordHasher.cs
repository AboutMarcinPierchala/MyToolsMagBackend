using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.Components.PasswordHasher
{
    public interface IPasswordHasher
    {
        public string[] Hash(string password);
        public string HashToCheck(string password, string hashedSalt);
    }
}
