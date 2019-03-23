using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        private List<Cash> cash;
        private List<Gem> gems;
        private List<Gold> golds;
        private long sumCash = 0;
        private long sumGem = 0;
        private long sumGold = 0;
        private long sumTotal = 0;

        public Bag(long limit)
        {
            this.Limit = limit;
            this.cash = new List<Cash>();
            this.gems = new List<Gem>();
            this.golds = new List<Gold>();
        }
        public long Limit { get; set; }

        public void AddCash(Cash cash)
        {
            if (this.sumGem >= cash.Amount + this.sumCash && this.sumTotal + cash.Amount <= this.Limit)
            {
                this.sumCash += cash.Amount;
                this.sumTotal += cash.Amount;
                if (this.cash.Any(x => x.Name == cash.Name))
                {
                    Cash currentCash = this.cash.FirstOrDefault(x => x.Name == cash.Name);
                    currentCash.Amount += cash.Amount;
                }
                else
                {
                    this.cash.Add(cash);
                }
            }
        }

        public void AddGem(Gem gem)
        {
            if (this.sumGold >= gem.Amount + this.sumGem && this.sumTotal + gem.Amount <= this.Limit)
            {
                this.sumGem += gem.Amount;
                this.sumTotal += gem.Amount;
                if (this.gems.Any(x => x.Name == gem.Name))
                {
                    Gem currentGem = this.gems.FirstOrDefault(x => x.Name == gem.Name);
                    currentGem.Amount += gem.Amount;
                }
                else
                {
                    this.gems.Add(gem);
                }
            }
        }

        public void AddGold(Gold gold)
        {
            if (this.sumTotal + gold.Amount <= this.Limit)
            {
                this.golds.Add(gold);
                this.sumGold += gold.Amount;
                this.sumTotal += gold.Amount;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.golds.Any())
            {
                sb.AppendLine(DisplaysTheValueOfTheTreasureType("Gold", this.sumGold));
                sb.AppendLine($"##Gold - {this.sumGold}");
            }

            if (this.gems.Any())
            {
                sb.AppendLine(DisplaysTheValueOfTheTreasureType("Gem", this.sumGem));
                foreach (var item in this.gems.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine(item.ToString());
                }
            }

            if (this.cash.Any())
            {
                sb.AppendLine(DisplaysTheValueOfTheTreasureType("Cash", this.sumCash));
                foreach (var item in this.cash.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

        private string DisplaysTheValueOfTheTreasureType(string v, long sum)
        {
            return $"<{v}> ${sum}";
        }
    }
}
