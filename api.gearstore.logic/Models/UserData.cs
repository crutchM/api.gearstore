using System;
using System.ComponentModel.DataAnnotations;

namespace api.gearstore.logic.Models
{
    public class UserData
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set;}

        public UserData(long id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public UserData() { }

        public static UserData GetDummyInstance()
        {
            return new UserData
            {
                Id = -1,
                Username = "Username",
                Password = "Password"
            };
        }

        public void CopyFrom(UserData user)
        {
            Username = user.Username;
            Password = user.Password;
        }
    }
}
