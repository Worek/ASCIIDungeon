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
        private bool isItsTour { get; set; }

        private bool isAlive { get; set; }


        public Character(string name, List<Skill> list, int maxHealth, string race)
        {
            this.nameOfCharacter = name;
            this.listOfSkills = list;
            this.maxHealth = maxHealth;
            this.healthOfCharacter = this.maxHealth;
            this.isAlive = true;
            this.race = this.race;
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
    }
}
