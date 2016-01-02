namespace TeamLichTestAutomation.Utilities.Attributes
{
    using System;

    public class TestOwnerAttribute : Attribute
    {
        private Owner owner;

        public TestOwnerAttribute(Owner owner)
        {
            this.Owner = owner;
        }

        public Owner Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }
    }
}