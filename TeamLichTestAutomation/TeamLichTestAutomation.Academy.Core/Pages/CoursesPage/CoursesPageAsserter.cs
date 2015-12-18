namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using System.Linq;
    using System.Threading;
    using ArtOfTest.Common.UnitTesting;

    public static class CoursesPageAsserter
    {
        public static void AssertSignOffBtn(this CoursesPage coursesPage)
        {
            var s = coursesPage.SignOff;
            Thread.Sleep(2000);
            var signOffButtonExists = s.IsVisible();

            Assert.IsTrue(signOffButtonExists);
        }

        public static void AssertCoursesFound(this CoursesPage coursesPage)
        {
            var title = "Курсове";

            Assert.AreEqual(title, coursesPage.Title.InnerText);
        }
    }
}
