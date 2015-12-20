namespace TeamLichTestAutomation.Academy.Core.Models
{
    public class User
    {
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public User(string userName, string password, string firstName, string lastName, string email) 
            : this(userName, password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public static User Regular
        {
            get
            {
                return new User("TeamLichTestUser", "123456");
            }
        }

        public static User Admin
        {
            get
            {
                return new User("TeamLichTestAdmin", "123456");
            }
        }

        public static User FullValidInformation
        {
            get 
            {
                return new User("LichTestUser", "123456", "Първото", "Фамилията", "mailtest@test.com");
            }
        }
    }
}