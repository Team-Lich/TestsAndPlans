namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using System.Linq;
    using ArtOfTest.Common.UnitTesting;

    public static class CoursesPageAsserter
    {
        public static void AssertSignOffBtn(this CoursesPage coursesPage)
        {
            var message = "Отпишете курса";

           Assert.AreEqual(message, coursesPage.SignOff.InnerText);
        }

        public static void AssertCoursesFound(this CoursesPage coursesPage)
        {
            var title = "Курсове";

            Assert.AreEqual(title, coursesPage.Title.InnerText);
        }
    }
}
