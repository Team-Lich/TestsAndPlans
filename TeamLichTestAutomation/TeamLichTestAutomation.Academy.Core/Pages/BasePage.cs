namespace TeamLichTestAutomation.Academy.Core.Pages
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
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

        public T LocateById<T>(string id) where T : HtmlControl
        {
            this.browser.WaitForElement(5000, id);
            return this.browser.Find.ById<T>(id);
        }

        public T LocateById<T>(int timeout, string id) where T : HtmlControl
        {
            this.browser.WaitForElement(timeout, id);
            return this.browser.Find.ById<T>(id);
        }
    }
}