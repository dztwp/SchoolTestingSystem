using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Common.Entities
{
    public class User
    {
        public User(Guid id,string name,string surname,string login)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Login = login;
        }
        public User(string name,string surname, string login, string pass, string role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Login = login;
            HashedPassword = pass;
            Role = role;
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Login { get; set; }
        public string HashedPassword { get; set; }

        public string Role { get; set; }

    }
}
