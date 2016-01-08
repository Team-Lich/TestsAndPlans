namespace TeamLichTestAutomation.Academy.Core.Data
{
    public static class TelerikUserData
    {
        public static readonly string UsernameValid = "testUser";
        public static readonly string UsernameInvalidSymbols = "user*nam&e";
        public static readonly string UsernameStartingInvalidSymbol = "@username";
        public static readonly string UsernameEndingInvalidSymbol = "username&";
        public static readonly string UsernameInvalidLengthDown = "user";
        public static readonly string UsernameInvalidLengthUp = new string('r', 33);

        public static readonly string PasswordValid = "123456";
        public static readonly string PasswordInvalidLength = "123";
        public static readonly string PasswordAgainValid = "123abcd";

        public static readonly string FirstNameValid = "Първоиме";
        public static readonly string FirstNameInvalidLength = "П";
        public static readonly string FirstNameNonCyrillicSymbols = "Firstname";
        public static readonly string FirstNameInvalidBoundarySymbols = "%Първоиме&";

        public static readonly string LastNameValid = "Фамилия";
        public static readonly string LastNameInvalidLength = "Ф";
        public static readonly string LastNameInvalidSymbols = "Lastname";

        public static readonly string EmailValid = "testemail@mail.com";
        public static readonly string EmailMissingAtSymbol = "testmail.com";
        public static readonly string EmailMissingPointSymbol = "testemail@mail";
    }
}