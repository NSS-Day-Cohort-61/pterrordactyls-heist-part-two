using System;
using System.Collections.Generic;
using System.Reflection;

namespace Heist2
{
    class Program
    {
        static void Main(string[] args)
        {

            Hacker hack1 = new Hacker("Jade", 40, 25);
            Hacker hack2 = new Hacker("Akshay", 65, 25);
            LockSpecialist lock1 = new LockSpecialist("Cassie", 65, 25);
            LockSpecialist lock2 = new LockSpecialist("Franko", 20, 10);
            Muscle musc1 = new Muscle("Marek", 70, 25);
            Muscle musc2 = new Muscle("Joe Bibs", 50, 20);

            List<IRobber> rolodex = new List<IRobber>()
            {
                hack1, hack2, lock1, lock2, musc1, musc2
            };

        newMember:
            Console.WriteLine($"Available Operatives: {rolodex.Count}");
            Console.WriteLine("");

            Console.WriteLine("Who would you like to add to your rolodex?");
            string newName = Console.ReadLine();
        specs:
            Console.WriteLine($"What is {newName}'s specialty?");
            Console.WriteLine(@"1) Hacker (Disables alarms)
2) Muscle (Disarms guards)
3) Lock Specialist (cracks vault)");
            int newSpecialty = int.Parse(Console.ReadLine());

            if (newSpecialty == 1 || newSpecialty == 2 || newSpecialty == 3)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"It looks like {newName} doesn't have a specialty.");

                goto specs;
            }

            Console.WriteLine($"What is {newName}'s skill level? (0 - 100)");
            int newSkill = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine($"What is {newName}'s percent of the cut for a mission? (0 - 100)");
            int newPercent = int.Parse(Console.ReadLine());

            if (newSpecialty == 1)
            {
                Hacker newHacker = new Hacker(newName, newSkill, newPercent);
                rolodex.Add(newHacker);
            }
            else if (newSpecialty == 2)
            {
                Muscle newMuscle = new Muscle(newName, newSkill, newPercent);
                rolodex.Add(newMuscle);
            }
            else
            {
                LockSpecialist newLockSpecialist = new LockSpecialist(newName, newSkill, newPercent);
                rolodex.Add(newLockSpecialist);
            }


            Console.WriteLine("");
            Console.WriteLine("Is there anyone else to add to your rolodex? Yes/No");
            string ContinueAdd = Console.ReadLine().ToLower();
            if (ContinueAdd == "yes" || ContinueAdd == "y")
            {
                Console.WriteLine("");
                goto newMember;
            }

            Bank NewBank = new Bank
            {
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(49999, 100000001)

            };

            int MaxValue = NewBank.GetMaxSecurity();
            int MinValue = NewBank.GetMinSecurity();

            PropertyInfo[] props = NewBank.GetType().GetProperties();

            for (int i = 1; i < 4; i++)
            {
                if (int.Parse(props[i].GetValue(NewBank).ToString()) == MaxValue)
                {
                    Console.WriteLine($"Most Secure: {props[i].Name}");
                }
                else if (int.Parse(props[i].GetValue(NewBank).ToString()) == MinValue)
                {
                    Console.WriteLine($"Least Secure: {props[i].Name}");
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("");

            List<IRobber> Crew = new List<IRobber>();

            int index = 0;
            int CrewShares = 100;
        crew:
        newCrew:
            foreach (var item in rolodex)
            {
                if (!Crew.Contains(item) && item.PercentageCut <= CrewShares)
                {
                    Console.WriteLine(@$"Call Number: {index}
Name: {item.Name}
Specialty: {item.GetType().Name}
Skill Level: {item.SkillLevel}
Cut Percent: {item.PercentageCut}
");
                }

                index++;
            }
            index = 0;

            Console.WriteLine("Who are you calling to add to the crew?");
            int callNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (callNumber <= rolodex.Count)
            {
                Crew.Add(rolodex[callNumber]);
                CrewShares = CrewShares - rolodex[callNumber].PercentageCut;
            }
            else
            {
                Console.WriteLine("i can't find them in the rolodex. Choose someone else to call.");
                goto crew;
            }
            if (CrewShares > 0)
            {
                Console.WriteLine("Is there anyone else to add to call? Yes/No");
                string CrewAdd = Console.ReadLine().ToLower();
                if (CrewAdd == "yes" || CrewAdd == "y")
                {
                    goto newCrew;
                }
            }
            else
            {
                Console.WriteLine("Your team is full.");
                Console.WriteLine("");
            }

            List<string> HackerTools = new List<string>()
            {
                "Thumbdrive", "Quantum Computer", "BT Speaker", "Dark Web", "Gun"
            };

            List<string> MuscleTools = new List<string>()
            {
                "Brass Knuckles", "Darksaber", "Nunchucks", "Zipties", "Gun"
            };

            List<string> LockPickTools = new List<string>()
            {
                "Lockpick 3000", "Laser Drill", "Screwdiver", "NanoTech Lockpick", "Gun"
            };

            foreach (var member in Crew)
            {

                if (member.GetType().Name == "Hacker")
                {
                    member.GetTools(HackerTools, NewBank);
                }
                else if (member.GetType().Name == "Muscle")
                {
                    member.GetTools(MuscleTools, NewBank);
                }
                else
                {
                    member.GetTools(LockPickTools, NewBank);
                }
            }


            if (NewBank.IsSecure)
            {

                if (NewBank.AlarmScore > 0)
                {

                    foreach (var mem in Crew)
                    {
                        if (mem.GetType().Name == "Hacker")
                        {
                            Console.WriteLine($"The heist was a failure. {mem.Name} couldn't hack it as a hacker. ");

                        }
                        else
                        {
                            Console.WriteLine("The heist was a failure. No hacker.");
                        }
                    }
                }
                if (NewBank.SecurityGuardScore > 0)
                {
                    foreach (var mem in Crew)
                    {
                        if (mem.GetType().Name == "Muscle")
                        {
                            Console.WriteLine($"The heist was a failure. {mem.Name} didn't have enough muscle for the job.");
                        }
                        else
                        {
                            Console.WriteLine("The heist was a failure. No muscle.");
                        }
                    }
                }
                if (NewBank.VaultScore > 0)
                {
                    foreach (var mem in Crew)
                    {
                        if (mem.GetType().Name == "LockSpecialist")
                        {
                            Console.WriteLine($"The heist was a failure. {mem.Name} could't crack the locks, i guess they weren't the right pick.");
                        }
                        else
                        {
                            Console.WriteLine("The heist was a failure. No lock specialist.");
                        }
                    }
                }

            }
            else
            {
                List<string> escapeRoutes = new List<string>()
                {
                    "The Bahamas", "Barbados", "Trinidad", "Argentina", "Switzerland"
                };

                foreach (var mem in Crew)
                {
                    int location = new Random().Next(0, escapeRoutes.Count);
                    int numberShares = NewBank.CashOnHand / mem.PercentageCut;
                    Console.WriteLine($"{mem.Name} escaped with ${numberShares.ToString("#,##0")} to {escapeRoutes[location]}");
                }
            }


        }
    }
}
