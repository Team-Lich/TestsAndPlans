namespace TeamLichTestAutomation.Academy.Core.Models
{
    public class TelerikUser
    {
        public TelerikUser(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public TelerikUser(string userName, string password, string firstName, string lastName, string email) 
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

        public static TelerikUser Regular
        {
            get
            {
                return new TelerikUser("TeamLichTestUser", "123456");
            }
        }

        public static TelerikUser Admin
        {
            get
            {
                return new TelerikUser("TeamLichTestAdmin", "123456");
            }
        }

        public static TelerikUser FullValidInformation
        {
            get 
            {
                return new TelerikUser("LichTestUser", "123456", "Първото", "Фамилията", "mailtest@test.com");
            }
        }
    }
}