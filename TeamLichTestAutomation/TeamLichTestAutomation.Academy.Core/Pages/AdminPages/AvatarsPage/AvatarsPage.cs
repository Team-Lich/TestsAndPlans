namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class AvatarsPage : BasePage
    {
        public AvatarsPage(Browser browser)
           : base(browser)
        {
        }

        public void BackToAdmin()
        {
            this.BackToAdminButton.Click();
        }
    }
}