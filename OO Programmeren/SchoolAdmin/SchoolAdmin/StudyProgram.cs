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
        public ImmutableList<Course> Courses { get; }//readonly autoproperty

        public StudyProgram(string name, ImmutableList<Course> courses) 
        {
            this.name = name;
            //readonly poperty 's kan alleen bij de start van het maken van het object toegewezen worden
            this.Courses = courses;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
       
        public void ShowOverview()
        {
            //intro text
            string introText = $"Programma: {name}";
            Console.WriteLine(introText);
            Console.WriteLine(String.Empty.PadLeft(introText.Length,'*'));
            //Space
            Console.WriteLine();
            //Lijst van al de vakken
            for(int i = 0; i < Courses.Count; i++)
            {
                //toon het vak
                Console.WriteLine($"{Courses[i].Title} ({i+1}) sp({Courses[i].CreditPoints})");
            }

            //Space
            Console.WriteLine();
        }

        public void Remove(Course input)
        {
            //voor elke course in Courses
            foreach (var k in Courses)
            {

                if (k != input)
                {
                    throw new Exception("Ingevoerde richting is er niet");
                }
                Courses.Remove(k);
            }
        }



        //DEMO'S
        public static void DemoStudyProgram()
        {
            //Maken van verschillende vak objecten
            Course commu = new Course("Communicatie");
            Course pro = new Course("Programmeren");
            Course data = new Course("Databanken");
            Course sec = new Course("Security");

            //steek al de vakken in een  onveranderlijke lijst
            var courses = ImmutableList<Course>.Empty
                .Add(commu)
                .Add(pro)
                .Add(data)
                .Add(sec);

            //maak de studie programma's
            StudyProgram programmerenProgram = new StudyProgram("Programmeren",courses);
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer",courses);

            //Databanken verwijderen uit richt snbProgram
            //Door Remove gaan de bestaande lijst aanpassen en deze terug geven bij het aanmaken van de studyprogram
            snbProgram = new StudyProgram("Systeem- en netwerkbeheer",snbProgram.Courses.Remove(data));
            //Entry aanpassen
            //Hiervoor gaan we ook een nieuwe studyprogram maken door de insert de aanpassing te laten doen
          
            programmerenProgram = new StudyProgram("Programmeren", programmerenProgram.Courses.Insert(1, new Course("Scripting")));
            //Inhoud tonen van bijde richtingen
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();
            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }


    }
}