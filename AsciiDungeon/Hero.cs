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
        public int healthOfCharacter { get; private set; }
        public int maxHealth { get; private set; }
        public string race { get; private set; }
        public string nameOfCharacter { get; private set; }
        public List<Skill> listOfSkills { get; private set; }
        public StatisticsOfCharacter stats { get; private set; }
        private bool isItsTour { get; set; }

        private bool isAlive { get; set; }


        public Character(string name, List<Skill> list, string race, StatisticsOfCharacter stats)
        {
            this.nameOfCharacter = name;
            this.listOfSkills = list;
            this.isAlive = true;
            this.race = this.race;
            this.stats = stats;
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

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.AppendLine($"Imie: {this.nameOfCharacter} Rasa: {this.race} HP: {this.stats.health}/{this.stats.maxHealth}");
            foreach (var val in listOfSkills)
                returnString.AppendLine(val.ToString());
            return returnString.ToString();
        }
    }
}
