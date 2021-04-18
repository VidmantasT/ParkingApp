using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp
{
    public class User
    {
        private string username;
        private string password;

        public User(string _username, string _password)
        {
            this.username = _username;
            this.password = _password;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public string GetPassword()
        {
            return this.password;
        }
    }
}
