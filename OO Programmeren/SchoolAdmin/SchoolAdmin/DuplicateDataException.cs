namespace SchoolAdmin
{
    internal class DuplicateDataException : Exception
    {
        public Object Object1 { get; }
        public Object Object2 { get; }

        public DuplicateDataException(string message, Object object1, Object object2) : base(message)
        {
            Object1 = object1;
            Object2 = object2;
        }
    }
}