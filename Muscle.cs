using System;
using System.Collections.Generic;

namespace Heist2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;

            Console.WriteLine($"{Name} is dealing with the guards. Security is down by {SkillLevel}.");

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} took out the guards. One less thing to worry about.");
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

        public Muscle(string newName, int newSkill, int newPercent)
        {
            Name = newName;
            SkillLevel = newSkill;
            PercentageCut = newPercent;
        }
    }
}