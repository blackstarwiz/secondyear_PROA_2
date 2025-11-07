using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        private List<Course> courses = new List<Course>();
        public ImmutableList<Course> Courses
        {
            get
            {
                return courses.ToImmutableList<Course>();
            }
        }
        public StudyProgram(string name)
        {
            this.name = name;
        }

        public void ShowOverview()
        {
            Console.WriteLine($"Programma: {Name}\n");
            foreach (Course course in Courses)
            {
                course.ShowOverview();
            }
        }
        public static void DemoStudyProgram()
        {
            //bug 1 en oplossing
            //Course communicatie = new Course("Communicatie");
            //Course programmeren = new Course("Programmeren");
            //Course databanken = new Course("Databanken");
            //List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            ////aanpassing na eerste bug: nieuwe courses
            //List<Course> coursesSNB = new List<Course>() { communicatie, programmeren, databanken };
            //StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            //StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");
            //programmerenProgram.Courses = coursesProgrammeren;
            //snbProgram.Courses = coursesSNB;
            ////we willen hieronder Databanken schrappen uit het programma SNB
            //snbProgram.Courses.Remove(databanken);
            //programmerenProgram.ShowOverview();
            //snbProgram.ShowOverview();

            //bug 2 en oplossing
            //Course communicatie = new Course("Communicatie");
            //Course programmeren = new Course("Programmeren");
            //Course databanken = new Course("Databanken");
            //List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            //List<Course> coursesSNB = new List<Course>() { communicatie, programmeren, databanken };
            //StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            //StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");
            //programmerenProgram.Courses = coursesProgrammeren;
            //snbProgram.Courses = coursesSNB;
            ////we willen hieronder Databanken schrappen uit het programma SNB
            //snbProgram.Courses.Remove(databanken);
            ////voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            //snbProgram.Courses[1].Title = "Scripting";
            //programmerenProgram.ShowOverview();
            //snbProgram.ShowOverview();

            //bug 2  oplossing
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");
            Course scripting = new Course("programmeren");
            List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            List<Course> coursesSNB = new List<Course>() { communicatie, scripting, databanken };
            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");
            //Wijziging van COurses naar courses
            programmerenProgram.courses = coursesProgrammeren;
            snbProgram.courses = coursesSNB;
            //we willen hieronder Databanken schrappen uit het programma SNB
            //wijziging van Courses naar courses
            snbProgram.courses.Remove(databanken);
            //voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            snbProgram.Courses[1].Title = "Scripting";
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
        }
    }
}
