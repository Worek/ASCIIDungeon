using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Character
    {
        public int positionInLine { get; private set; }
        public string race { get; private set; }
        public string nameOfCharacter { get; private set; }
        public List<Skill> listOfSkills { get; private set; }
        public List<Item> itemList { get; private set; }
        public StatisticsOfCharacter stats { get; private set; }
        private bool isItsTour { get; set; }

        public bool isAlive { get; private set; }


        public Character(string name, List<Skill> list, string race, StatisticsOfCharacter stats)
        {
            this.nameOfCharacter = name;
            this.listOfSkills = list;
            this.isAlive = true;
            this.race = this.race;
            this.stats = stats;
            itemList = new List<Item>();
            for (int i = 0; i < listOfSkills.Count(); i++)
            {
                listOfSkills[i].skillNumber = i;
            }
        }

        public Character(Character clone)
        {
            this.nameOfCharacter = clone.nameOfCharacter;
            this.positionInLine = clone.positionInLine;
            this.race = clone.race;
            this.isAlive = clone.isAlive;
            this.listOfSkills = new List<Skill>();
            foreach (var val in clone.listOfSkills)
                this.listOfSkills.Add(new Skill(val));
            
            this.stats = new StatisticsOfCharacter(clone.stats);
            this.itemList = new List<Item>();
            foreach (var val in clone.itemList)
                this.itemList.Add(new Item(val));
        }

        public void grantItem(Item item)
        {
            itemList.Add(item);
            item.positionInBag = itemList.Count()-1;
        }

        public string getNameOfCharachter() {
            if (isAlive)
            {
                if (isItsTour)
                    return nameOfCharacter.ToUpper();
                else
                    return nameOfCharacter.ToLower();
            }
            else
                return graphicDefines.getKilledMark(); ;
        }

        public void getDamage(int value)
        {
            stats.health -= value;
            if (stats.health < 0)
            {
                isAlive = false;
                stats.health = 0;
            }
        }

        public void useItem(Item item)
        {
            if (item.healthEffect != 0)
                stats.health += item.healthEffect;
            if (item.defenceEffect != 0)
                stats.defence += item.defenceEffect;
            itemList.Remove(item);
            for(int i = 0; i<itemList.Count; i++)
            {
                itemList[i].positionInBag = i;
            }
        }

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.AppendLine($"Imie: {this.nameOfCharacter} Rasa: {this.race} HP: {this.stats.health}/{this.stats.maxHealth}");
            foreach (var val in listOfSkills)
                returnString.AppendLine(val.ToString());
            foreach (var val in itemList)
                returnString.AppendLine(val.ToString());
            return returnString.ToString();
        }
    }
}
