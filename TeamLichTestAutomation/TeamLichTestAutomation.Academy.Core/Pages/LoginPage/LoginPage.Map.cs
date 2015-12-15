namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class LoginPage
    {
        private HtmlInputText UserTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputText>("UsernameOrEmail");
            }
        }

        private HtmlInputPassword PassTextBox
        {
            get
            {
                return this.Browser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        private HtmlInputSubmit SubmitButton
        {
            get
            {
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("value=Вход");
            }
        }
    }
}