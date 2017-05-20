using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    //głowna biblioteka (?) grafiki
    abstract class graphicDefines
    {

        static public string getWall()
        {
            return "||";
        }
        static public string getFloor()
        {
            
            return "_________________________________________";
        }

        static public string getSpaceBetweenTeams()
        {
            return "   ";
        }

        static public string getSpaceOfFreePosition()
        {
            return "(--)";
        }
        static public string getCopyright()
        {
            return "Copyright \u00A9 Patryk Bober 209861";
        }

        static public string getKilledMark()
        {
            return "-x-";
        }

        static public string getSpceBerofeCharacters()
        {
            return "        ";
        }
    }
}
