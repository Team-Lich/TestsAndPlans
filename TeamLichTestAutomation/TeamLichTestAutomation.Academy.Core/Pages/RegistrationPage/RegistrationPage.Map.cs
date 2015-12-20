namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class RegistrationPage
    {
        private HtmlInputText UsernameTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Username");
                return this.Browser.Find.ById<HtmlInputText>("Username");
            }
        }

        private HtmlInputPassword PasswordTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Password");
                return this.Browser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        private HtmlInputPassword RepeatPasswordTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=PasswordAgain");
                return this.Browser.Find.ById<HtmlInputPassword>("PasswordAgain");
            }
        }

        private HtmlInputText FirstNameTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=FirstName");
                return this.Browser.Find.ById<HtmlInputText>("FirstName");
            }
        }

        private HtmlInputText LastNameTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=LastName");
                return this.Browser.Find.ById<HtmlInputText>("LastName");
            }
        }

        private HtmlInputText EmailTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Email");
                return this.Browser.Find.ById<HtmlInputText>("Email");
            }
        }

        private HtmlInputCheckBox TermAndConditionsCheckBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=TermsAndConditions");
                return this.Browser.Find.ById<HtmlInputCheckBox>("TermsAndConditions");
            }
        }

        private HtmlInputSubmit SubmitButton
        {
            get
            {
                this.Browser.WaitForElement(5000, "value=Регистрация");
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("value=Регистрация");
            }
        }

        internal HtmlSpan UsernameErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Username-error");

                return this.Browser.Find.ById<HtmlSpan>("Username-error");
            }
        }

        internal HtmlSpan LastNameErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=LastName-error");
                return this.Browser.Find.ById<HtmlSpan>("LastName-error");
            }
        }

        internal HtmlSpan LastNameМandatoryErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=LastName-error");
                return this.Browser.Find.ById<HtmlSpan>("LastName-error");
            }
        }

        internal HtmlDiv ConditionsErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "class=validation-summary-errors");
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=validation-summary-errors");
            }
        }

        internal HtmlSpan PasswordAgainErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=PasswordAgain-error");
                return this.Browser.Find.ById<HtmlSpan>("PasswordAgain-error");
            }
        }

        internal HtmlSpan IncorrectPasswordLengthErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Password-error");
                return this.Browser.Find.ById<HtmlSpan>("Password-error");
            }
        }

        internal HtmlSpan IncorrectUsernameLengthErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Username-error");
                return this.Browser.Find.ById<HtmlSpan>("Username-error");
            }
        }

        internal HtmlSpan EmailErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Email-error");
                return this.Browser.Find.ById<HtmlSpan>("Email-error");
            }
        }

        internal HtmlSpan FirstNameErrorMessage
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=FirstName-error");
                return this.Browser.Find.ById<HtmlSpan>("FirstName-error");
            }
        }
    }
}