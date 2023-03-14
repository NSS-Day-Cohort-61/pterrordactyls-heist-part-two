using System;

namespace Heist2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;

            Console.WriteLine($"{Name} is dealing with the vault. Security is down by {SkillLevel}.");

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"We've gotten into the vault! Good work {Name}.");
            }
        }

        public LockSpecialist(string newName, int newSkill, int newPercent)
        {
            Name = newName;
            SkillLevel = newSkill;
            PercentageCut = newPercent;
        }
    }
}