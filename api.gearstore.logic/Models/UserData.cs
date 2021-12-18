using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.gearstore.logic.Models
{
    public class UserData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set;}
        
        public string Email { get; set; }
        
        public string Phone { get; set; }

        public UserData(string username, string password, string email, string phone)
        {
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
        }

        public void CopyFrom(UserData user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
            Phone = user.Phone;
        }
    }
}
