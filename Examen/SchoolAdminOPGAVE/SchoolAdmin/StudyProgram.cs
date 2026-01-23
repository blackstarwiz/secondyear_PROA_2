using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class StudyProgram
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private Dictionary<Course, byte> courses = new Dictionary<Course, byte>();

        public ImmutableDictionary<Course, byte> Courses
        {
            get { return courses.ToImmutableDictionary<Course, byte>(); }

        }
        public StudyProgram(string name)
        {
            this.name = name;
        }

        public void ShowOverview()
        {
            Console.WriteLine($"Programma: {Name}\n");
             Console.WriteLine("Semester 1:");
            bool noCourses = true;
            foreach (var item in Courses)
            {
                if(item.Value==1)
                {
                    item.Key.ShowOverview();
                    noCourses = false;
                }
            }
            if (noCourses)
            {
                Console.WriteLine("Er zijn geen cursussen in semester 1\n");
            }
            noCourses = true;
            Console.WriteLine("Semester 2:");
            foreach (var item in Courses)
            {
                if (item.Value == 2)
                {
                    item.Key.ShowOverview();
                    noCourses = false;
                }
            }
            if (noCourses)
            {
                Console.WriteLine("Er zijn geen cursussen in semester 2\n");
            }
        }
        public static void DemoStudyProgram()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");
            Course scripting = new Course("programmeren");;
            var coursesProgrammeren = new Dictionary<Course, byte>{{communicatie,1},{programmeren,1},{databanken,1}};
            var coursesSNB = new Dictionary<Course, byte>{{communicatie,2},{scripting,1},{databanken,1}};

            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            programmerenProgram.courses = coursesProgrammeren;
            snbProgram.courses = coursesSNB;

            snbProgram.courses.Remove(databanken);
            foreach (var item in snbProgram.Courses)
            {
                if(item.Key.Title=="programmeren")
                {
                    item.Key.Title = "scripting";
                }
            }
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
        }
    }
}
