namespace TeamLichTestAutomation.Academy.Core.Models
{
    using TeamLichTestAutomation.Academy.Core.Data;

    public class TelerikUser
    {
        public TelerikUser(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.Url = "http://stage.telerikacademy.com/Users/" + userName;
        }

        public TelerikUser(string userName, string password, string firstName, string lastName, string email)
            : this(userName, password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

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

        public static TelerikUser Related1
        {
            get
            {
                return new TelerikUser("TeamLichRelatedUser1", "123456");
            }
        }

        public static TelerikUser Related2
        {
            get
            {
                return new TelerikUser("TeamLichRelatedUser2", "123456");
            }
        }

        public static TelerikUser FullValidInformation
        {
            get
            {
                return new TelerikUser("LichTestUser", "123456", "Първото", "Фамилията", "mailtest@test.com");
            }
        }

        public static TelerikUser ValidUser
        {
            get
            {
                return new TelerikUser(
                TelerikUserData.UsernameValid,
                TelerikUserData.PasswordValid,
                TelerikUserData.FirstNameValid,
                TelerikUserData.LastNameValid,
                TelerikUserData.EmailValid);
            }
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Url { get; set; }
    }
}