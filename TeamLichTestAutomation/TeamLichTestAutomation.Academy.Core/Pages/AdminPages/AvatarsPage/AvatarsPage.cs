namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Core;
    using System.Threading;
    using System.Windows.Forms;

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

        public void ExportAsExcel()
            {
            Manager manager = Manager.Current;
            this.Browser.RefreshDomTree();

            manager.Desktop.Mouse.Click(MouseClickType.LeftClick, this.ExportAsExcelButton.GetRectangle());
            Thread.Sleep(4000);

            switch (this.Browser.BrowserType)
                {
                case BrowserType.Chrome:
                        {
                        manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
                        break;
                        }
                default:
                        {
                        this.Browser.Desktop.KeyBoard.KeyDown(Keys.Alt);
                        this.Browser.Desktop.KeyBoard.KeyPress(Keys.S);
                        this.Browser.Desktop.KeyBoard.KeyUp(Keys.Alt);
                        break;
                        }
                }

            // Waiting for download to finish
            Thread.Sleep(5000);
            }
    }
}