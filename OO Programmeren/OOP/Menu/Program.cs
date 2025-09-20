namespace Menu
{
    internal class Program
    {
        private bool sub_isActive = true;
        private bool hoofd_isActive = true;
        private string[] topic = ["DateTime", "Programma afsluiten"];

        private static void Main(string[] args)
        {
            int keuzeTopic = 0;
            Program Menu = new Program();

            do
            {
                Console.WriteLine("Topic van de uit te voeren oefening");

                for (int i = 0; i < Menu.topic.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Menu.topic[i]}");
                }

                Console.Write("> ");

                keuzeTopic = Convert.ToInt32(Console.ReadLine());

                try
                {
                    if (keuzeTopic % Menu.topic.Length != 0)
                    {
                        Menu.ToonSubMenu(keuzeTopic);
                        Console.ReadKey();
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
                            string[] h10 = ["H10-dag-van-de-week", "H10-ticks-sinds-2000", "H10-schrikkelteller", "afsluiten"];
                            int h10Len = h10.Length - 1;

                            for (int i = 0; i < h10.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {h10[i]}");
                            }

                            Console.Write("> ");

                            int subKeuze = Convert.ToInt32(Console.ReadLine());

                            switch (subKeuze)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine(DateTimeOefeningen.DagVanDeWeek());
                                        sub_isActive = false;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"{0}", e.Message);
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine($"Sinds 1 januari 2000 zijn er {DateTimeOefeningen.Ticks2000Programma().ToString("N0")} ticks voorbijgegaan.");
                                    break;

                                case 3:
                                    
                                    Console.Write("Geef een jaar in: ");
                                    int jaar = Convert.ToInt32(Console.ReadLine());

                                    DateTime thisYear = DateTime.Now;

                                    try
                                    {
                                        Console.WriteLine($"Er zijn {DateTimeOefeningen.SchrikkeljaarProgramma(jaar)} schikkeljaren tussen {jaar} en {thisYear.ToString("yyyy")}");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    break;

                                default:
                                    if (subKeuze == h10.Length)
                                    {
                                        Console.WriteLine("Terug naar hoofd Menu");
                                        sub_isActive = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingevoerde keuze staat niet in de lijst, Klik op Enter");
                                        Console.ReadKey();
                                    }

                                    break;
                            }
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