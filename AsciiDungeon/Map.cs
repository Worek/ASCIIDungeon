using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Map
    {
        public List<Position> listOfPositionsOfHeroes { get; set; }
        public List<Position> listOfPositionsOfVillans { get; set; }

        public Map()
        {
            listOfPositionsOfHeroes = new List<Position>() { new Position(1), new Position(2), new Position(3), new Position(4) };
            listOfPositionsOfVillans = new List<Position>() { new Position(1), new Position(2), new Position(3), new Position(4)};
        }

        public bool addHero(Character hero)
        {
            int iteratorOnPositions = 0;
            while (iteratorOnPositions <= 3)
            {
                if (!listOfPositionsOfHeroes[iteratorOnPositions].isSomeoneOnThisPosition)
                {
                    listOfPositionsOfHeroes[iteratorOnPositions].setCharacterToThisPosition(hero);
                    iteratorOnPositions = 10;
                }
                iteratorOnPositions++;
            }
            if (iteratorOnPositions == 4)
                return false;
            else
                return true;
        }

        public bool addVillan(Character villan)
        {
            int iteratorOnPositions = 0;
            while (iteratorOnPositions <= 3)
            {
                if (!listOfPositionsOfVillans[iteratorOnPositions].isSomeoneOnThisPosition)
                {
                    listOfPositionsOfVillans[iteratorOnPositions].setCharacterToThisPosition(villan);
                    iteratorOnPositions = 10;
                }
                iteratorOnPositions++;
            }
            if (iteratorOnPositions == 4)
                return false;
            else
                return true;
        }


        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            //drukowanie bochaterow
            foreach (var val in listOfPositionsOfHeroes)
                returnString.Append(val.getNameOfCharackterOnPosition());
            returnString.Append(graphicDefines.getSpaceBetweenTeams());
            //drukowanie potworow
            foreach (var val in listOfPositionsOfVillans)
                returnString.Append(val.getNameOfCharackterOnPosition());
            return returnString.ToString();
        }
    }
}
