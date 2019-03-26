namespace P08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Army
    {
        private HashSet<ISoldier> soldiers;

        public Army()
        {
            this.soldiers = new HashSet<ISoldier>();
        }

        public void AddSoldier(ISoldier soldier)
        {
            this.soldiers.Add(soldier);
        }

        public HashSet<Private> GetPrivates(int[] ids)
        {
            HashSet<Private> privates = new HashSet<Private>();
            for (int i = 0; i < ids.Length; i++)
            {
                if (this.soldiers.Any(x => x.Id == ids[i]))
                {
                    ISoldier currentPrivate = this.soldiers.FirstOrDefault(x => x.Id == ids[i]);
                    privates.Add((Private)currentPrivate);
                }
            }

            return privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ISoldier item in this.soldiers)
            {
                if (item is Spy)
                {
                    sb.AppendLine(((Spy)item).ToString());
                }
                else if (item is Private)
                {
                    sb.AppendLine(((Private)item).ToString());
                }
                else if (item is LieutenantGeneral)
                {
                    sb.AppendLine(((LieutenantGeneral)item).ToString());
                }
                else if (item is Engineer)
                {
                    sb.AppendLine(((Engineer)item).ToString());
                }
                else if (item is Commando)
                {
                    sb.AppendLine(((Commando)item).ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}