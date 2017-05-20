using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Position
    {
        public int numberOfPosition { get; private set; }
        private Character characterOnPosition { get; set; }
        public bool isSomeoneOnThisPosition { get; private set; }

        public Position(int numberOfPosition)
        {
            this.numberOfPosition = numberOfPosition;
            this.isSomeoneOnThisPosition = false;
        }

        public bool setCharacterToThisPosition(Character character)
        {
            if (this.isSomeoneOnThisPosition)
                return false;
            else
            {
                this.isSomeoneOnThisPosition = true;
                this.characterOnPosition = character;
                return true;
            }
        }

        public Character getChararcterOnPosition()
        {
            if (this.isSomeoneOnThisPosition)
                return this.characterOnPosition;
            else
                return null;
        }

        public string getNameOfCharackterOnPosition()
        {
            if (this.isSomeoneOnThisPosition)
            {
                if (characterOnPosition.isAlive)
                    return this.characterOnPosition.nameOfCharacter;
                else
                    return graphicDefines.getKilledMark();
            }
            else
                return graphicDefines.getSpaceOfFreePosition();
        }

        public override string ToString()
        {
            return this.characterOnPosition.nameOfCharacter;
        }
    }
}
