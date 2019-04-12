namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Models;
    using Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Item> pool;
        private List<Character> party;
        private int counter;
        public DungeonMaster()
        {
            this.pool = new List<Item>();
            this.party = new List<Character>();
        }


        public string JoinParty(string[] args)
        {
            string faction = args[0];
            if (faction != "CSharp" && faction != "Java")
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            string characterType = args[1];
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }

            Type classType = typeof(DungeonMaster).Assembly.GetTypes().FirstOrDefault(x => x.Name == characterType);

            string name = args[2];

            var instance = (Character)Activator.CreateInstance(classType, new object[] { name, parsedFaction });
            this.party.Add(instance);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];
            if (itemType != "PoisonPotion" && itemType != "HealthPotion" && itemType != "ArmorRepairKit")
            {
                throw new ArgumentException($"Invalid item \"{itemType}\"!");
            }

            Type classType = typeof(DungeonMaster).Assembly.GetTypes().FirstOrDefault(x => x.Name == itemType);
            var instance = (Item)Activator.CreateInstance(classType, new object[] { });

            this.pool.Add(instance);
            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.pool.Last();

            character.Bag.AddItem(item);

            this.pool.Remove(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (character.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character character = this.party.FirstOrDefault(x => x.Name == giverName);
            if (character == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiverCharacter = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {itemName} not found!");
            }

            character.UseItemOn(item, receiverCharacter);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character character = this.party.FirstOrDefault(x => x.Name == giverName);
            if (character == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiverCharacter = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            if (item == null)
            {
                throw new ArgumentException($"Character {itemName} not found!");
            }

            character.GiveCharacterItem(item, receiverCharacter);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character character = this.party.FirstOrDefault(x => x.Name == attackerName);
            if (character == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(character is IAttackable))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            IAttackable attacker = character;
            if (receiver.IsAlive && character.IsAlive)
            {
                attacker.Attack(receiver);
            }

            string result = $"{attackerName} attacks {receiverName} for {character.AbilityPoints} hit points! {receiverName} has " +
                $"{receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
            if (receiver.IsAlive == false)
            {
                result += $"\n{receiverName} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (!(healer is IHealable) && receiver is IAttackable && healer.IsAlive && receiver.IsAlive)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            IHealable healer1 = healer;
            healer1.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.party.Where(x => x.IsAlive == true))
            {
                double healthBeforeRest = item.Health;
                item.Rest();
                sb.AppendLine($"{item.Name} rests ({healthBeforeRest} => {item.Health})");
            }

            List<Character> aliveCharacters = this.party.Where(x => x.IsAlive == true).ToList();
            if (aliveCharacters.Count <= 1)
            {
                if (aliveCharacters.Count == 1)
                {
                    counter++;
                }
                foreach (var item in this.party.Where(x => x.IsAlive == true))
                {
                    double healthBeforeRest = item.Health;
                    item.Rest();
                    sb.Append($"{item.Name} rests ({healthBeforeRest} => {item.Health})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            bool result = false;
            List<Character> aliveCharacters = this.party.Where(x => x.IsAlive == true).ToList();
            if (counter == 1 && aliveCharacters.Count == 1)
            {
                result = true;
            }

            return result;
        }
    }
}
