namespace TeamLichTestAutomation.Academy.Core.Pages.RegistrationPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class RegistrationPage
    {
        private HtmlInputText UsernameTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("Username");
            }
        }

        private HtmlInputPassword PasswordTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        private HtmlInputPassword RepeatPasswordTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputPassword>("PasswordAgain");
            }
        }

        private HtmlInputText FirstNameTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("FirstName");
            }
        }

        private HtmlInputText LastNameTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("LastName");
            }
        }

        private HtmlInputText EmailTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("Email");
            }
        }

        private HtmlInputCheckBox TermAndConditionsCheckBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputCheckBox>("TermsAndConditions");
            }
        }

        private HtmlInputSubmit SubmitButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("value=Регистрация");
            }
        }

        internal HtmlSpan UsernameErrorMessage
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("Username-error");
            }
        }

        internal HtmlSpan LastNameErrorMessage
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("LastName-error");
            }
        }

        internal HtmlSpan LastNameМandatoryErrorMessage
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("LastName-error");
            }
        }

        internal HtmlDiv ConditionsErrorMessage
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=validation-summary-errors");
            }
        }

        internal HtmlSpan DifferentPasswordErrorMessage
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("PasswordAgain-error");
            }
        }

        internal HtmlSpan IncorrectPasswordLengthErrorMessage
        {
            get
            {
                return this.Browser.Find.ById<HtmlSpan>("Password-error");
            }
        }
    }
}
