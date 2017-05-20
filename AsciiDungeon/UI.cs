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

        //--Drukowanie informacji o bochaterach
        static public void printHeroesInfo(Map actuallMap)
        {
            Console.WriteLine("Bochaterowie: ");
            foreach (var val in actuallMap.listOfPositionsOfHeroes)
                Console.WriteLine(val.getChararcterOnPosition());
        }
        static public void printVillansInfo(Map actuallMap)
        {
            Console.WriteLine("Wrogowie: ");
            foreach (var val in actuallMap.listOfPositionsOfVillans)
                Console.WriteLine(val.getChararcterOnPosition());
        }

        static public void printAllCommands()
        {
            Console.Clear();
            Console.WriteLine("{0,-15}-> wyswietla ten tekst", definsCommands.commnadForHelp);
            Console.WriteLine("modol game:");
            Console.WriteLine("{0,-15}-> wyjscie z gry", definsCommands.commandForGameExit);

            Console.WriteLine("Aby kontynuowac nacisnij <ENTER>");
            Console.ReadKey();
        }
    }
}
