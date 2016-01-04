namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.WebAii.Core;

    public partial class MessagesPage : BasePage
    {
        private readonly string url = "http://stage.telerikacademy.com/Messages";

        public MessagesPage(Browser browser)
            : base(browser)
        {
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }
    }
}