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

        private HtmlInputText PasswordTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("Password");
            }
        }

        private HtmlInputText RepeatPasswordTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("PasswordAgain");
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
    }
}
