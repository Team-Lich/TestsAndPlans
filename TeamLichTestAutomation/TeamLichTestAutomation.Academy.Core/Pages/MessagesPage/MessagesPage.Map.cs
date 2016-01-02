namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using System.Collections.Generic;

    public partial class MessagesPage
    {
        public HtmlControl MessagesHeading
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlControl>("class=sectionTitle");
            }
        }

        public HtmlControl MessagePanelTitle
        {
            get
            {
                return this.Browser.Find.AllByAttributes<HtmlControl>("class=panel-title")[0];
            }
        }

        public HtmlDiv InfoMessage
        {
            get
            {
                return this.Browser.Find.ByAttributes<HtmlDiv>("class=infoMessageSend");
            }
        }

        public HtmlTextArea MessageToSendTextArea
        {
            get
            {
                return this.Browser.Find.ById<HtmlTextArea>("messageToSend");
            }
        }

        public HtmlDiv SubmitByEnterCheckbox
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("submitByEnter");
            }
        }

        public HtmlDiv SendButton
        {
            get
            {
                return this.Browser.Find.ById<HtmlDiv>("sendButton");
            }
        }

        public HtmlControl FriendsPanelTitle
        {
            get
            {
                return this.Browser.Find.AllByAttributes<HtmlControl>("class=panel-title")[1];
            }
        }

        public HtmlInputText FriendSearchInput
        {
            get
            {
                return this.Browser.Find.ByName<HtmlInputText>("friendQuery");
            }
        }

        public ICollection<HtmlDiv> FriendItemsCollection
        {
            get
            {
                return this.Browser.Find.AllByExpression<HtmlDiv>("class=~friend", "class=~bgSuccessDark");
            }
        }
    }
}
