namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class LoginPage
    {
        public HtmlListItem[] ErrorsShown
        {
            get
            {
                this.Browser.WaitForElement(5000, "class=validation-summary-errors");
                var container = this.Browser.Find.ByExpression<HtmlDiv>("class=validation-summary-errors");
                var list = container.Find.AllByTagName<HtmlUnorderedList>("ul")[0];
                var listItems = list.Find.AllByTagName<HtmlListItem>("li");

                var result = new HtmlListItem[listItems.Count];

                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = listItems[i];
                }

                return result;
            }
        }

        private HtmlInputText UserTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=UsernameOrEmail");
                return this.Browser.Find.ById<HtmlInputText>("UsernameOrEmail");
            }
        }

        private HtmlInputPassword PassTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Password");
                return this.Browser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        private HtmlInputSubmit SubmitButton
        {
            get
            {
                this.Browser.WaitForElement(5000, "value=Вход");
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("value=Вход");
            }
        }
    }
}