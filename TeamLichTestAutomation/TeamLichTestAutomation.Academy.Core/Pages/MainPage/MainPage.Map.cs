namespace TeamLichTestAutomation.Academy.Core.Pages.MainPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class MainPage : BasePage
    {
        internal HtmlAnchor LoginButton
        {
            get
            {
                return this.Browser.Find.ById<HtmlAnchor>("EntranceButton");
            }
        }
    }
}
