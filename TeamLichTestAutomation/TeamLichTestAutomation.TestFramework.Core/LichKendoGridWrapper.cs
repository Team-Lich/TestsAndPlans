namespace TeamLichTestAutomation.TestFramework.Core
{
    using ArtOfTest.WebAii.ObjectModel;
    using Telerik.TestingFramework.Controls.KendoUI;

    public class LichKendoGridWrapper
    {
        private readonly KendoGrid grid;

        public LichKendoGridWrapper(KendoGrid grid)
        {
            this.grid = grid;
        }

        public KendoGrid Grid 
        {
            get
            {
                return this.grid;
            }
        }

        public bool Contains(string stringToSearch)
        {
            var listOfItems = this.grid.FindItems(i => i.InnerText == stringToSearch);
            return listOfItems.Count > 0;
        }
    }
}