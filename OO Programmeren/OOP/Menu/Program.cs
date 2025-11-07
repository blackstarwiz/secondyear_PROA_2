namespace Menu
{
    internal class Program
    {
        private bool sub_isActive = true;
        private bool hoofd_isActive = true;
        private string[] topic = ["DateTime", "ClassesAndObjects", "Datastructuren", "Inheritance", "Programma afsluiten"];

        private static void Main(string[] args)
        {
            int keuzeTopic = 0;
            Program Menu = new Program();

            do
            {
                Console.Clear();
                Console.WriteLine("Topic van de uit te voeren oefening");

                for (int i = 0; i < Menu.topic.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Menu.topic[i]}");
                }

                Console.Write("> ");

                keuzeTopic = Convert.ToInt32(Console.ReadLine());
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
                            string[] h10 = ["H10-dag-van-de-week", "H10-ticks-sinds-2000", "H10-schrikkelteller", "H10-simpele-timing", "H10-verjaardag-v2", "H10-Getallencombinatie", "H10-Figures", "Terug naar Hoofdmenu"];
                            int h10Len = h10.Length - 1;

                            for (int i = 0; i < h10.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {h10[i]}");
                            }

                            Console.Write("> ");

                            int sub1Keuze = Convert.ToInt32(Console.ReadLine());

                            switch (sub1Keuze)
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

                                case 4:
                                    Console.WriteLine($"Het duurt {DateTimeOefeningen.ArrayTimerProgramma()} milliseconden om een array van een miljoen elementen aan te maken en op te vullen met opeenvolgende waarden.");
                                    break;

                                case 5:
                                    Console.WriteLine(DateTimeOefeningen.VerjaardagProgramma());
                                    break;

                                case 6:
                                    DateTimeOefeningen.EigenObjectOefeningen();
                                    break;

                                case 7:

                                    ClassesAndObjects.DemoFigures();

                                    break;
                                case 8:
                                    Inheritance.ShowSubMenu();
                                    break;

                                default:
                                    if (sub1Keuze == h10.Length)
                                    {
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

                        case 2:
                            string[] h11 = ["H11-FiguresWithConstructor", "H11-FoodPurchase", "Terug naar Hoofdmenu"];
                            int h11Len = h11.Length - 1;

                            for (int i = 0; i < h11.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {h11[i]}");
                            }

                            Console.Write("> ");

                            int sub2Keuze = Convert.ToInt32(Console.ReadLine());

                            switch (sub2Keuze)
                            {
                                case 1:
                                    ClassesAndObjects.DemoFigures();
                                    break;

                                case 2:
                                    try
                                    {
                                        FoodPurchase.DemoPurchase();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    break;

                                default:
                                    if (sub2Keuze == h11.Length)
                                    {
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

                        case 3:
                            string[] h13 = ["H13-PhoneBookNameNumber","H13-PhoneBookCityNameNumber", "Terug naar Hoofdmenu"];
                            int h13Len = h13.Length - 1;

                            for (int i = 0; i < h13.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {h13[i]}");
                            }

                            Console.Write("> ");

                            int sub3Keuze = Convert.ToInt32(Console.ReadLine());

                            switch (sub3Keuze)
                            {
                                case 1:
                                    try
                                    {
                                        Datastructuren.PhoneBookNameNumber();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"{0}", e.Message);
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        
                                        Datastructuren.PhoneBookCityNameNumber();
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    break;
                                default:
                                    if (sub3Keuze == h13.Length)
                                    {
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
                        case 4:
                            Inheritance.ShowSubMenu();
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