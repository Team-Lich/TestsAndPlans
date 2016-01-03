namespace TeamLichTestAutomation.Utilities.Attributes
{
    using System;

    public class TestPriorityAttribute : Attribute
    {
        private Priority priority;

        public TestPriorityAttribute(Priority priority)
        {
            this.Priority = priority;
        }

        public Priority Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }
    }
}