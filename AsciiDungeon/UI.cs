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

        static public void printAttackSequence(Character attacer, Character defender, int skillNumber, string additionalInfo ="")
        {
            Console.Clear();
            if (additionalInfo.Length > 0)
                Console.WriteLine(additionalInfo);
            Console.WriteLine("{0} atakuje {1} przy pomocy skilla\n{2}", attacer.nameOfCharacter, defender.nameOfCharacter, attacer.listOfSkills[skillNumber].nameOfSkill);
            Console.ReadKey();
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
            Console.WriteLine("{0,-45}->poprawne polecenie uzycia przedmiotu", definsCommands.rightUseItemCommand);

            Console.WriteLine("Aby kontynuowac nacisnij <ENTER>");
            Console.ReadKey();
        }

        //Texty końca gry

        static public void printWinMessege()
        {
            Console.Clear();
            Console.WriteLine("Udalo ci sie pokonac zle potwory!\nDzieki tobie krolestwo znow jest bezpieczne... Ale ksiezniczka jest w innym zamku, musisz jej znowu poszukac\n\n");
            Console.WriteLine("\n\n\n\nCzekaj jaka ksiezniczka...Jakie krolestwo? Ja mialem tylko posprzatac ta jaskinie...");
            Console.ReadKey();
        }

        static public void printLostMessege()
        {
            Console.Clear();
            Console.WriteLine("Niestety twoi bochaterowie zostali zjedzeni na obiad przez potwory... no coz, moze nastepnym sie lepiej poszczesci");
            Console.WriteLine("Za to ty siedzisz spokojnie przed ekranem wysylajac na zez kolejne postacie.....\n\n\n\n\nLUBIE CIE!");
            Console.ReadKey();
        }

        static public void printFailMessege(Exception e)
        {
            Console.Clear();
            Console.WriteLine("Ups cos poszlo nie tak... Cos sie skielbasilo i wysypalo...\n\nAle nie ma sie co martwic! Zespol swietnie wyszkolonych potworow zostal wyslany w celu naprawy bledu... Do serwerowni... Gdzie jest ciemno... Zupelnie jak w lochu... \nPrzypadek?");
            if(e!=null)
            Console.WriteLine(e.Message);
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
