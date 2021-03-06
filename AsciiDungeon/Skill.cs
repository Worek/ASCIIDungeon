﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Skill
    {
        public string nameOfSkill { get; private set; }
        public SkillEffect skillEffect { get; private set; }
        public Skill(string name, SkillEffect effect)
        {
            this.nameOfSkill = name;
            this.skillEffect = effect;
        }

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append($"{this.nameOfSkill} -> obrazenia: {this.skillEffect.damege} szansa trafienia: {this.skillEffect.chanceOfSucces}");
            return returnString.ToString();
        }
    }
}
