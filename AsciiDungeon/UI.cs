using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class UI
    {
        static public void printOnConsoleMapStatus(Map mapStatus) // algorytm drukowania w komponencie
        {
            Console.Write(graphicDefines.getSpceBerofeCharacters());
            Console.WriteLine(mapStatus);
            Console.WriteLine(graphicDefines.getFloor());
        }

        static public void printHelloMessege()
        {
            Console.WriteLine("ASCII DUNGEON \nGra stworzona jako projekt na przedmiot SI\n <Nacisnij Enter>");
            Console.WriteLine(graphicDefines.getCopyright());
            Console.ReadKey();
        }
    }
}
