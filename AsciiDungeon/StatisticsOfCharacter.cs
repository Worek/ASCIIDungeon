using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class StatisticsOfCharacter
    {
        public int health { get; set; }                //zdrowie postaci
        public int maxHealth { get; set; }                // maxymalene zdrowie postaci
        public int strength { get; set; }              // sila postaci
        public int inteligence { get; set; }           // inteligencja postaci
        public int defence { get; set; }               // obrona postaci -> nie wiem czy wykorzystam na si

        public StatisticsOfCharacter(int maxHealth, int strength, int inteligence, int defence)
        {
            this.maxHealth = maxHealth;
            health = maxHealth;
            this.strength = strength;
            this.inteligence = inteligence;
            this.defence = defence;
        }
    }
}
