namespace TeamLichTestAutomation.Utilities.Attributes
{
    using System;

    public class TestIdAttribute : Attribute
    {
        private int testId;

        public TestIdAttribute(int testId)
        {
            this.TestId = testId;
        }

        public int TestId
        {
            get
            {
                return this.testId;
            }

            set
            {
                this.testId = value;
            }
        }
    }
}