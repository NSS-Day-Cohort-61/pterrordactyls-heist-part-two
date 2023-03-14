using System;
using System.Collections.Generic;

namespace Heist2
{
    public interface IRobber
    {
        string Name { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }

        void PerformSkill(Bank bank)
        {

        }

        void GetTools(List<string> HackerTools, Bank NewBank)
        {

        }


    }
}