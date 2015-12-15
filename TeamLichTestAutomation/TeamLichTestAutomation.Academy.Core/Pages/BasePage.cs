namespace TeamLichTestAutomation.Academy.Core.Pages
{
    using ArtOfTest.WebAii.Core;

    public abstract class BasePage
    {
        private readonly Browser browser;
 
        public BasePage(Browser browser)
        {
            this.browser = browser;
        }

        public Browser Browser
        {
            get
            {
                return this.browser;
            }
        }
    }
}