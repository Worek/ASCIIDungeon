using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Item : IEquatable<Item>
    {
        public string nameOfItem { get; private set; }
        public int healthEffect { get; private set; }
        public int defenceEffect { get; private set; }

        public int positionInBag { get; set; }

        public Item(Item clone)
        {
            this.nameOfItem = clone.nameOfItem;
            this.healthEffect = clone.healthEffect;
            this.defenceEffect = clone.defenceEffect;
            this.positionInBag = clone.positionInBag;
        }

        public Item(string name, int he, int de)
        {
            this.nameOfItem = name;
            this.healthEffect = he;
            this.defenceEffect = de;
        }

        public bool Equals(Item other)
        {
            if (this.nameOfItem == other.nameOfItem && this.defenceEffect == other.defenceEffect && this.healthEffect == other.healthEffect)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            if (healthEffect != 0)
                return $"{this.nameOfItem}: leczenie: {this.healthEffect}";
            else
                return $"{this.nameOfItem}: leczenie: {this.defenceEffect}";
        }

        

    }
}
