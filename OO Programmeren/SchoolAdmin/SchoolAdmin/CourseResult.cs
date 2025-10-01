namespace SchoolAdmin
{
    //CourseResult is bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
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