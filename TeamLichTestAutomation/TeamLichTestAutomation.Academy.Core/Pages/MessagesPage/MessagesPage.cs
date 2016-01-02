namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    using Models;

    public partial class MessagesPage : BasePage
    {
        public MessagesPage(Browser browser)
            : base(browser)
        {
        }

        public HtmlDiv FriendItem()
        {
            foreach (var friend in this.FriendItemsCollection)
            {
                if (friend.Find.ByAttributes<HtmlDiv>("data-username=" + TelerikUser.Related2.UserName) != null)
                {
                    return friend;
                }
            }

            return null;
        }
    }
}
