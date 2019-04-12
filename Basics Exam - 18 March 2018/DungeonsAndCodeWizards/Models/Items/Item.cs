using System;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        public Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
