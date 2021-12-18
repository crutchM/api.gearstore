namespace api.gearstore.logic.Models
{
    public class UserData
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set;}
        
        public string Email { get; set; }
        
        public string Phone { get; set; }

        public UserData(long id, string username, string password, string email, string phone)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
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
            Email = user.Email;
            Phone = user.Phone;
        }
    }
}
