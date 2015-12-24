namespace TeamLichTestAutomation.Academy.Core.Pages.AdminPages.UniversitiesPage
{
    using ArtOfTest.WebAii.Core;
    using System.Drawing;
    using Telerik.TestingFramework.Controls.KendoUI;

    public partial class UniversitiesPage : BasePage
    {
        public UniversitiesPage(Browser browser)
            : base(browser)
        {
        }

        public void AddUniversity(string universityName)
        {
            this.AddButton.Click();

            var currentManager = Manager.Current;

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftDoubleClick, this.NameTextbox.GetRectangle());
            currentManager.Desktop.KeyBoard.TypeText(universityName, 50);

            currentManager.Desktop.Mouse.Click(MouseClickType.LeftClick, this.NameTextbox.GetRectangle().Right + 10, this.NameTextbox.GetRectangle().Top + 10);

            this.UpdateButton.Click();
        }

        public void DeleteRow(string value, int column)
        {
            
        }
    }
}