namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
    using ArtOfTest.Common.UnitTesting;
    using System.Threading;

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
            var value = coursesPage.Title.GetValue<string>("innerText");
            Assert.AreEqual(title, value);
        }

        public static void AssertLecturePresent(this CoursesPage coursesPage)
        {
            var firstCourse = coursesPage.FirstCourse;
            Assert.IsNotNull(firstCourse);
        }

        public static void AssertSendHomeworkLinkPresent(this CoursesPage coursesPage)
        {
            var link = coursesPage.SendHomeworkLink;
            Assert.IsNotNull(link);
        }

        public static void AssertPresentationLinkPresent(this CoursesPage coursesPage)
        {
            var link = coursesPage.PresentationLink;
            Assert.IsNotNull(link);
        }
    }
}