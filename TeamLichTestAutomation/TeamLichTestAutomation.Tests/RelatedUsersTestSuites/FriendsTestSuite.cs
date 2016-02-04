namespace TeamLichTestAutomation.Tests.RelatedUsersTestSuites
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamLichTestAutomation.Academy.Core.Models;
    using TeamLichTestAutomation.Academy.Core.Pages.FriendsPage;
    using TeamLichTestAutomation.Academy.Core.Pages.LoginPage;
    using TeamLichTestAutomation.Academy.Core.Pages.MainPage;
    using TeamLichTestAutomation.Academy.Core.Pages.UserProfilePage;

    using TeamLichTestAutomation.Utilities.Attributes;

    [TestClass]
    public class FriendsTestSuite : BaseTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;
        private UserProfilePage userPage;
        private FriendsPage friendsPage;

        [TestInitialize]
        public void ThisTestInitialize()
        {
            this.mainPage = new MainPage(this.Browser);
            this.loginPage = new LoginPage(this.Browser);
            this.userPage = new UserProfilePage(this.Browser);
            this.friendsPage = new FriendsPage(this.Browser);

            this.mainPage.NavigateTo(this.loginPage.Url);
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(106)]
        [Priority(3)]
        [Owner("Yane")]
        public void AddFriendButtonShoudBeVisible()
        {
            RelatedUsersUtilities.RemoveFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.AssertAddFriendButtonIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(107)]
        [Priority(3)]
        [Owner("Yane")]
        public void RemoveFriendButtonShoudBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);

            this.userPage.AssertRemoveFriendButtonIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(108)]
        [Priority(3)]
        [Owner("Yane")]
        public void AddFriendButtonShouldWorksCorrectly()
        {
            RelatedUsersUtilities.RemoveFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);
            this.userPage.ClickAddFriendButton();
            this.userPage.Browser.WaitForElement(2000, "id=UnfriendButton");

            this.userPage.AssertRemoveFriendButtonIsVisible();

            this.mainPage.LogoutButton.Click();
            this.mainPage.NavigateTo(this.loginPage.Url);
            this.loginPage.LoginUser(TelerikUser.Related2);
            this.mainPage.NavigateTo(this.friendsPage.Url);
            this.friendsPage.ClickApproveFriendshipIcon();

            this.friendsPage.AssertFriendsListPanelBodyContainsFriend();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(109)]
        [Priority(3)]
        [Owner("Yane")]
        public void RemoveFriendButtonShouldWorksCorrectly()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(TelerikUser.Related2.Url);
            this.userPage.ClickRemoveFriendButton();
            this.userPage.Browser.WaitForElement(2000, "id=AddFriendButton");

            this.userPage.AssertAddFriendButtonIsVisible();

            this.mainPage.LogoutButton.Click();
            this.mainPage.NavigateTo(this.loginPage.Url);
            this.loginPage.LoginUser(TelerikUser.Related2);
            this.mainPage.NavigateTo(this.friendsPage.Url);
            this.friendsPage.RemoveAllFriends();

            this.friendsPage.AssertFriendIsRemovedFromFriendsListPanelBody();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(110)]
        [Priority(3)]
        [Owner("Yane")]
        public void FriendsListShouldContainNoFriends()
        {
            this.loginPage.LoginUser(TelerikUser.Related1);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.RemoveAllFriends();
            this.friendsPage.Browser.Refresh();

            this.friendsPage.AssertNoFriendsMessageIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(111)]
        [Priority(3)]
        [Owner("Yane")]
        public void FriendsListShouldContainFriends()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.AssertFriendsListPanelHasProperHeading();
            this.friendsPage.AssertFriendsListPanelBodyContainsFriend();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(112)]
        [Priority(3)]
        [Owner("Yane")]
        public void RemoveFriendConfirmationShouldBeVisible()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.ClickRemoveFriendshipIcon();

            this.friendsPage.AssertConfirmationIsVisible();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(113)]
        [Priority(3)]
        [Owner("Yane")]
        public void RemoveFriendAfterConfirmYes()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.ClickRemoveFriendshipIcon();
            this.friendsPage.ClickRemoveFriendshipConfirmYes();

            this.friendsPage.AssertFriendIsRemovedFromFriendsListPanelBody();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(114)]
        [Priority(3)]
        [Owner("Yane")]
        public void KeepFriendAfterConfirmNo()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.ClickRemoveFriendshipIcon();
            this.friendsPage.ClickRemoveFriendshipConfirmNo();

            this.friendsPage.AssertFriendsListPanelBodyContainsFriend();
        }

        [TestMethod]
        [TestCategory("Friends")]
        [TestId(115)]
        [Priority(3)]
        [Owner("Yane")]
        public void ClickOnFriendItemShouldOpenHisProfile()
        {
            RelatedUsersUtilities.AddFriend(this.Browser);
            this.mainPage.NavigateTo(this.friendsPage.Url);

            this.friendsPage.ClickFriendItem();
            this.friendsPage.Browser.WaitUntilReady();
            this.friendsPage.Browser.RefreshDomTree();

            this.friendsPage.AssertProperUserProfilePageIsActive(TelerikUser.Related2.UserName);
        }
    }
}