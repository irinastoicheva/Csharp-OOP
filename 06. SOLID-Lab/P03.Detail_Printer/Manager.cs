namespace P03.DetailPrinter
{
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee, IPrint
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Print()}");
            foreach (var item in this.Documents)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
