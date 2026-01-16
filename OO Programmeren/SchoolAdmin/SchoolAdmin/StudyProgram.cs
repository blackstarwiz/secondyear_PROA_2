using System.Collections;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private readonly string? name;

        private static Dictionary<StudyProgram, ImmutableList<Course>> allStudyPrograms = new Dictionary<StudyProgram, ImmutableList<Course>>();

        public StudyProgram(string name, ImmutableList<Course> courses)
        {
            if (string.IsNullOrEmpty(name))
                return;
            this.name = name;

            allStudyPrograms.Add(this, courses);
        }

        public StudyProgram() : this(string.Empty, ImmutableList<Course>.Empty)
        {
        }

        public string? Name
        {
            get
            {
                return name;
            }
        }

        public ImmutableDictionary<StudyProgram, ImmutableList<Course>> AllStudyPrograms
        {
            get
            {
                return allStudyPrograms.ToImmutableDictionary();
            }
        }

        public ImmutableList<Course>? Courses
        {
            get
            {
                foreach (var studyprogram in AllStudyPrograms)
                {
                    if (studyprogram.Key.Name == this.Name)
                        return studyprogram.Value;
                }
                return ImmutableList<Course>.Empty;
            }
        }

        public void ShowOverview()
        {
            string introText = $"Programma: {name}";

            Console.WriteLine(introText);
            Console.WriteLine(string.Empty.PadLeft(introText.Length, '*'));
            Console.WriteLine();

            if (Courses is not null)
                for (int i = 0; i < Courses.Count; i++)
                {
                    Console.WriteLine($"{Courses[i].Title} ({i + 1}) sp({Courses[i].CreditPoints})");
                }

            Console.WriteLine();
        }

        public ImmutableList<Course> Remove(Course input)
        {
            var updatedCourses = ImmutableList<Course>.Empty;
            if (Courses is not null)
            {
                if (!Courses.Contains(input))
                {
                    throw new Exception("Ingevoerde richting is er niet");
                }

                updatedCourses = Courses.Remove(input);
            }

            return updatedCourses;
        }

        public ImmutableList<Course> Insert(int pos, Course input)
        {
            if (Courses is not null)

                return Courses.Insert(pos, input);

            return ImmutableList<Course>.Empty;
        }

        public void DemoStudyProgram()
        {
            Console.Clear();

            //Als Dictonary niet leeg is gaan we de gemaakte studyPrograms.ShowOverview aanspreken
            if (!AllStudyPrograms.IsEmpty)
            {
                foreach (var x in AllStudyPrograms)
                {
                    if (x.Key is not StudyProgram)
                        continue;

                    x.Key.ShowOverview();
                }
                Console.WriteLine("Druk op Enter:");
                Console.Write("> ");
                Console.ReadKey();
                return;
            }

            //We maken verschillenden vak objecten
            Course commu = new Course("Communicatie");
            Course pro = new Course("Programmeren");
            Course data = new Course("Databanken");
            Course sec = new Course("Security");

            //We maken een lijst van Vakken
            var courses = ImmutableList<Course>.Empty
                .Add(commu)
                .Add(pro)
                .Add(data)
                .Add(sec);

            StudyProgram programmerenProgram = new StudyProgram("Programmeren", courses);
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer", courses);

            //Verwijderen van vakk-object (Course)
            snbProgram.Remove(sec);
            //Nieuw vak toevoegen op bepaalde index
            programmerenProgram.Insert(1, new Course("Scripting"));

            //Toon alles
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }
    }
}