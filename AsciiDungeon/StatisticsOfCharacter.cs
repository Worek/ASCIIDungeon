﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class StatisticsOfCharacter
    {
        public int health { get; private set; }                //zdrowie postaci
        public int strength { get; private set; }              // sila postaci
        public int inteligence { get; set; }           // inteligencja postaci
        public int defence { get; private set; }               // obrona postaci -> nie wiem czy wykorzystam na si
    }
}