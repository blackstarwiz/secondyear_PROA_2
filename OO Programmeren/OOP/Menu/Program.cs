namespace Menu
{
    internal class Program
    {
        private bool sub_isActive = true;
        private bool hoofd_isActive = true;
        private string[] topic = ["DateTime", "ClassesAndObjects", "Datastructuren", "Inheritance", "Exeption Handeling", "Programma afsluiten"];

        private static void Main(string[] args)
        {
            int keuzeTopic = 0;
            Program Menu = new Program();

            do
            {
                Console.Clear();
                Console.WriteLine("Topic van de uit te voeren oefening");
                keuzeTopic = 0;

                for (int i = 0; i < Menu.topic.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Menu.topic[i]}");
                }

                Console.Write("> ");
                try
                {
                    keuzeTopic = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
                Console.Clear();
                try
                {
                    if (keuzeTopic % Menu.topic.Length != 0)
                    {
                        Menu.ToonSubMenu(keuzeTopic);
                        Console.Clear();
                        Menu.hoofd_isActive = true;
                    }
                    else
                    {
                        Console.WriteLine("Programma wordt afgesloten");
                        Menu.hoofd_isActive = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Menu.hoofd_isActive = true;
                }
            } while (Menu.hoofd_isActive);
        }

        public void ToonSubMenu(int topicNum)
        {
            if (topicNum % topic.Length != 0)
            {
                Console.WriteLine("Uit te voeren oefening");

                do
                {
                    switch (topicNum)
                    {
                        case 1:

                            DateTimeOefeningen.ShowSubMenu();
                            sub_isActive = false;
                            break;

                        case 2:

                            ClassesAndObjects.ShowSubMenu();
                            sub_isActive = false;
                            break;

                        case 3:
                            Datastructuren.ShowSubMenu();
                            sub_isActive = false;
                            break;

                        case 4:
                            Inheritance.ShowSubMenu();
                            sub_isActive = false;
                            break;

                        case 5:
                            ExeptionHandeling.ShowSubMenu();
                            sub_isActive = false;
                            break;

                        default:
                            Console.WriteLine("Dit zou topic#2 moeten zijn, terug keren naar hoofdmenu");
                            sub_isActive = false;
                            break;
                    }
                } while (sub_isActive);
            }
            else
            {
                throw new Exception("Topic staat niet in de lijst, terug naar Menu");
            }
        }
    }
}