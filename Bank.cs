using System.Collections.Generic;
using System;
using System.Linq;

namespace Heist2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure
        {
            get
            {
                if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public int GetMaxSecurity()
        {
            return new List<int> { this.AlarmScore, this.VaultScore, this.SecurityGuardScore }.Max();

        }
        public int GetMinSecurity()
        {
            return new List<int> { this.AlarmScore, this.VaultScore, this.SecurityGuardScore }.Min();

        }

    }
}

