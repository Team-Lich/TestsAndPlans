namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    public static class RegistrationPageErrorMessages
    {
        public const string UsernameMissing = "Потребителското име е задължително";

        public const string UsernameInvalid = "Потребителското име може да съдържа само малки и " +
                                              "главни латински букви, цифри и знаците точка и долна черта. ";

        public const string UsernameInvalidInitialSymbol = "Потребителското име трябва да започва с буква";

        public const string UsernameInvalidFinalSymbol = "и да завършва с буква или цифра.";

        public const string UsernameInvalidLength = "Потребителското име трябва да е между 5 и 32 символа";

        public const string PasswordMissing = "Паролата е задължителна";

        public const string PasswordInvalidLength = "Паролата трябва да е повече от 6 символа";

        public const string PasswordAgainDifferent = "Паролите не съвпадат";

        public const string PasswordAgainMissing = "Паролата отново е задължителна";

        public const string FirstNameMissing = "Името на български е задължително";

        public const string FirstNameNonCyrillicSymbol = "Името може да съдържа само букви от българската азбука и знака тире.";

        public const string FirstNameInvalidBoundarySymbols = "Името трябва да започва и да завършва с буква.";

        public const string LastNameInvalid = "Фамилията може да съдържа само букви от българската азбука " +
                                              "и знака тире. Фамилията трябва да започва и да завършва с буква.";

        public const string NameInvalidLength = "Минимална дължина - 2 букви.";

        public const string LastNameMissing = "Фамилията на български е задължителна";

        public const string EmailAddressMissing = "Имейлът е задължителен";

        public const string EmailAddressInvalid = "Моля въведете валиден имейл адрес.";

        public const string TermsAndConditionsUnaccepted = "За да се рагистрирате трябва да приемете " +
                                                           "условията и правилата на академията на Телерик";
    }
}