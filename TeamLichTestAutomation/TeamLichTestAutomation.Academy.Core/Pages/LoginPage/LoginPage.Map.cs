﻿namespace TeamLichTestAutomation.Academy.Core.Pages.LoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class LoginPage
    {
        private HtmlInputText UserTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=UsernameOrEmail");
                return this.Browser.Find.ById<HtmlInputText>("UsernameOrEmail");
            }
        }

        private HtmlInputPassword PassTextBox
        {
            get
            {
                this.Browser.WaitForElement(5000, "id=Password");
                return this.Browser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        private HtmlInputSubmit SubmitButton
        {
            get
            {
                this.Browser.WaitForElement(5000, "value=Вход");
                return this.Browser.Find.ByExpression<HtmlInputSubmit>("value=Вход");
            }
        }        
    }
}