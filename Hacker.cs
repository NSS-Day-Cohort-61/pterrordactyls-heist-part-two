using System;

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

        public Hacker(string newName, int newSkill, int newPercent)
        {
            Name = newName;
            SkillLevel = newSkill;
            PercentageCut = newPercent;
        }
    }
}