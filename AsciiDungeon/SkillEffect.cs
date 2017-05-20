using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class SkillEffect
    {
        public int chanceOfSucces { get; set; }    // szansa powodzenia się użycia skilla od 0 do 100
        public int damege { get; set; }            // zadawane obrażenia
        enum typeOfDmg                      // typ obrażeń -> na si tylko jedne
        {
            physic, 
        }

        public SkillEffect(int chanche, int damege)
        {
            this.chanceOfSucces = chanche;
            this.damege = damege;
        }
    }
}
