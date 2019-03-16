namespace P05_GreedyTimes
{
    public class Cash
    {
        public Cash(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
        public string Name { get; set; }

        public long Amount { get; set; }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}";
        }
    }
}
