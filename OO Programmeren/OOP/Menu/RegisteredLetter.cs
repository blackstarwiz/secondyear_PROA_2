using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class RegisteredLetter
    {
        private bool active = true;
        private double distance;
        private byte duration;
        private double price;

        private List<RegisteredLetter> letters = new List<RegisteredLetter>();

        public virtual double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("afstand is 0, Pakketje wordt terug gestuurd");
                    }
                    else
                    {
                        distance = value;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public virtual byte Duration
        {
            get
            {
                double checkDays = Math.Ceiling(distance / 100);

                duration = Convert.ToByte(checkDays);

                return duration;
            }
            set
            {
                duration = value;
            }
        }

        public virtual double Price
        {
            get
            {
                if (distance > 100)
                {
                    price = 15 + Math.Floor(distance / 100) * 10;
                }
                else
                {
                    price = 15.00;
                }
                return price;
            }
            set
            {
                price = value;
            }
        }

        public virtual void DemoPostOffice()
        {
            string[] options = ["Standaard", "Internationaal", "Hoge Priotiteit", "Geen enkele, we zijn er klaar met invoeren"];
            Console.WriteLine("Wil je nog een brief toevoegen? (ja/nee)");
            Console.Write("> ");
            string awnser = Console.ReadLine();
            int dis = 0;

            if (awnser.ToLower() == "ja")
            {
                do
                {
                    Console.WriteLine("Wat voor brif wil je toevoegen?");

                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{options[i]}");
                    }

                    Console.Write("> ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice % options.Length != 0)
                    {
                        Console.WriteLine("Hoe ver moet deze brief gaan?");
                        Console.Write("> ");
                        dis = Convert.ToInt32(Console.ReadLine());
                    }

                    switch (choice)
                    {
                        case 1:
                            Distance = dis;
                            letters.Add(this);
                            break;

                        case 2:
                            InternationalRegisteredLetter interLetter = new InternationalRegisteredLetter();

                            interLetter.Distance = dis;
                            letters.Add(interLetter);
                            break;

                        case 3:
                            HighPriorityRegisteredLetter highLetter = new HighPriorityRegisteredLetter();

                            highLetter.Distance = dis;
                            letters.Add(highLetter);
                            break;

                        default:
                            active = false;
                            break;
                    }
                } while (active);
            }
            else
            {
                Console.WriteLine("Volgende klant aub");
            }

            foreach (RegisteredLetter letter in letters)
            {
                Console.WriteLine($"Brief {letters.IndexOf(letter)+1}: {letter.Distance}Km, reistijd {letter.Duration} dagen, kostprijs {letter.Price} euro");
             }
        }
    }
}