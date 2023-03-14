using System;
using System.Collections.Generic;

namespace Heist2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;

            Console.WriteLine($"{Name} is dealing with the alarm. Security is down by {SkillLevel}.");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"We don't have to worry about the alarm anymore!");
            }
        }

        public void GetTools(List<string> HackerTools, Bank NewBank)
        {

            int HIndex = new Random().Next(0, 5);
            string HackTool = HackerTools[HIndex];

            if (HIndex != 1 && HIndex != 4)
            {
                this.SkillLevel = this.SkillLevel + 5;
            }
            else if (HIndex == 1)
            {
                NewBank.VaultScore = 0;
                NewBank.SecurityGuardScore = 0;
                NewBank.AlarmScore = 0;

            }
            else
            {
                this.SkillLevel = this.SkillLevel + 25;
            }
            this.PerformSkill(NewBank);
            Console.WriteLine($"Finish hack with {HackTool}");
        }

        public Hacker(string newName, int newSkill, int newPercent)
        {
            Name = newName;
            SkillLevel = newSkill;
            PercentageCut = newPercent;
        }
    }
}