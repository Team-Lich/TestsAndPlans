namespace TeamLichTestAutomation.Academy.Core.Data
{
    public static class TelerikUserData
    {
        public static string UsernameValid = "testUser";
        public static string UsernameInvalidSymbols = "user*nam&e";
        public static string UsernameStartingInvalidSymbol = "@username";
        public static string UsernameEndingInvalidSymbol = "username&";
        public static string UsernameInvalidLengthDown = "user";
        public static string UsernameInvalidLengthUp = new string('r', 33);

        public static string PasswordValid = "123456";
        public static string PasswordInvalidLength = "123";
        public static string PasswordAgainValid = "123abcd";

        public static string FirstNameValid = "Първоиме";
        public static string FirstNameInvalidLength = "П";
        public static string FirstNameNonCyrillicSymbols = "Firstname";
        public static string FirstNameInvalidBoundarySymbols = "%Първоиме&";

        public static string LastNameValid = "Фамилия";
        public static string LastNameInvalidLength = "Ф";
        public static string LastNameInvalidSymbols = "Lastname";

        public static string EmailValid = "testemail@mail.com";
        public static string EmailMissingAtSymbol = "testmail.com";
        public static string EmailMissingPointSymbol = "testemail@mail";
    }
}
