namespace TeamLichTestAutomation.Academy.Core.Pages.CoursesPage
{
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

        public static void AssertSendHomeworkLinkNotPresent(this CoursesPage coursesPage)
        {
            var link = coursesPage.SendHomeworkLink;
            Assert.IsNotNull(link);
        }

        public static void AssertPresentationLinkPresent(this CoursesPage coursesPage)
        {
            var link = coursesPage.PresentationLink;
            Assert.IsNotNull(link);
        }

        public static void AssertDownloadLastHwPresent(this CoursesPage coursesPage)
        {
            var link = coursesPage.PresentationLink;
            Assert.IsNotNull(link);
        }

        public static void AssertHomewrokEvalBtnPresent(this CoursesPage coursesPage)
        {
            var btn = coursesPage.EvalHomeworkBtn;
            Assert.IsNotNull(btn);
        }

        public static void AssertPleaseLogInBtnPresent(this CoursesPage coursesPage)
        {
            var btn = coursesPage.PleaseLogInBtn;
            Assert.IsNotNull(btn);
        }

        public static void AssertSignedOffCourse(this CoursesPage coursesPage)
        {
            var span = coursesPage.courseParticipationInfo;
            var actualText = @"Вие сте се отписалиот участие в този курс.";
            Assert.AreEqual(span.TextContent, actualText);
        }
    }
}