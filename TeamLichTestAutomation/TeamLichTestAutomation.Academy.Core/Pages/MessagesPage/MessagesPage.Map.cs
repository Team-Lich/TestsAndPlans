namespace TeamLichTestAutomation.Academy.Core.Pages.MessagesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Models;
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

        public HtmlInputText SearchField
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

        public HtmlDiv FriendItem
        {
            get
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

        public HtmlImage FriendAvatar
        {
            get
            {
                return FriendItem.Find.ByAttributes<HtmlImage>("class=img-thumbnail");
            }
        }

        public HtmlSpan FriendNames
        {
            get
            {
                return FriendItem.Find.ByAttributes<HtmlSpan>("class=friendName");
            }
        }

        public HtmlSpan FriendLastMessageBeginning
        {
            get
            {
                return FriendItem.Find.ByAttributes<HtmlSpan>("class=friendMessage");
            }
        }

        public HtmlSpan FriendLastMessageTime
        {
            get
            {
                return FriendItem.Find.ByExpression<HtmlSpan>("class=~friendTime");
            }
        }
    }
}