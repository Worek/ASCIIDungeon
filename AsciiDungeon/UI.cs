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

        static public void printAttackSequence(Character attacer, Character defender, int skillNumber)
        {
            Console.Clear();
            Console.WriteLine("{0} atakuje {1} przy pomocy skilla\n{2}", attacer.nameOfCharacter, defender.nameOfCharacter, attacer.listOfSkills[skillNumber].nameOfSkill);
        }

        static public void printAllCommands()
        {
            Console.Clear();
            Console.WriteLine("{0,-45}-> wyswietla ten tekst", definsCommands.commnadForHelp);
            Console.WriteLine("modol game:");
            Console.WriteLine("{0,-45}-> wyjscie z gry", definsCommands.commandForGameExit);

            Console.WriteLine("sterowanie postaciami");
            Console.WriteLine("{0,-45}->poprawne polecenie ataku", definsCommands.rightAttackCommand);
            Console.WriteLine("{0,-45}->poprawne polecenie poroszenia postaci", definsCommands.rightMoveCommand);

            Console.WriteLine("Aby kontynuowac nacisnij <ENTER>");
            Console.ReadKey();
        }

        static public void printMessege(string messege)
        {
            Console.WriteLine(messege);
            Console.ReadKey();
        }

        static public void printDebugText(string toPrint)
        {
            Console.WriteLine(toPrint);
            Console.ReadKey();
        }
    }
}
