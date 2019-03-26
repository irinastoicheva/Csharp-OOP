using System;

namespace P08.MilitaryElite
{
    public class SpecialisedSoldier : ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(string corps)
        {
            this.Corps = corps;
        }
        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
            }
        }
    }
}