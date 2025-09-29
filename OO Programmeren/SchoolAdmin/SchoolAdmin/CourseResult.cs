namespace SchoolAdmin
{
    internal class CourseResult
    {
        private string name;
        private byte result;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public byte Result
        {
            get
            {
                return result;
            }
            set
            {
                if(value > 20)
                {
                    Console.WriteLine("Ongeldig Cijfer");
                }
                else
                {
                    result = value;
                }
                    
            }
        }
    }
}