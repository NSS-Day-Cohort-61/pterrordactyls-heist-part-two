using System;

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

        public Muscle(string newName, int newSkill, int newPercent)
        {
            Name = newName;
            SkillLevel = newSkill;
            PercentageCut = newPercent;
        }
    }
}