using System;
using System.Collections.Generic;

namespace MiddlewareLibrary
{
    public class User : Entity
    {
        public string Name { get; }
        public string Surname { get; }
        public string Fullname => $"{Name} {Surname}";
        public string Login { get; }
        public string Password { get; }
        public List<Place> BookedPlaces { get; }

        public User() : base()
        {
            ID = "user-" + Guid.NewGuid().ToString();
            BookedPlaces = new List<Place>();
        }

        public User(string name, string surname, string login, string password) : this()
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }
    }
}