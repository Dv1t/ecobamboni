namespace Ecobamboni.Models
{
    public class User
    {
        public readonly string Login;
        public readonly string Password;
        public readonly int Role;

        public User(string login,string password, int role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}