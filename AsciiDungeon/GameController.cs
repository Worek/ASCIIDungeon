using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class GameController
    {
        private UI userInterface { get; set; }
        private Map actualMapOfGame { get; set; }
        private CharacterController characterController { get; set; }
        private String enteredCommand { get; set; }
        private enum commands
        {
            exit, attack, move, options, def, help
        }

        public GameController()
        {
            actualMapOfGame = new Map();
            characterController = new CharacterController();
        }

        //----------------------------Rozpoczecie nowej gry
        public void startNewGame()
        {
            
            UI.printHelloMessege();
            generateNewDefHeroes();
            mainLoop();
        }

        private void mainLoop()
        {
            do
            {
                
                Console.Clear();
                UI.printOnConsoleMapStatus(actualMapOfGame);
                UI.printHeroesInfo(actualMapOfGame);
                UI.printVillansInfo(actualMapOfGame);
                writeCommandAgain:
                enteredCommand = Console.ReadLine();
                switch (parseCommand(enteredCommand))
                {
                    case commands.help:
                        UI.printAllCommands();
                        break;

                    case commands.attack:
                        characterController.attack(enteredCommand, actualMapOfGame);
                        break;

                    case commands.move:
                        break;

                    case commands.exit:
                        //nic nie zrobi bo trza wyjsc :P
                        break;
                    default:
                        Console.WriteLine("Niepoprawna komenda\nWpisz <help> by uzyskac liste wszystkich komend");
                        goto writeCommandAgain;
                }
            }while (!enteredCommand.Equals(definsCommands.commandForGameExit));
        }


        private commands parseCommand(string enteredCommand)
        {
            if (enteredCommand.Equals(definsCommands.commandForGameExit))
                return commands.exit;
            if (enteredCommand.Equals(definsCommands.commnadForHelp))
                return commands.help;
            if (enteredCommand.Contains(definsCommands.commandForAttack))
                return commands.attack;
            if (enteredCommand.Contains(definsCommands.commandForMove))
                return commands.move;
            return commands.def;
        }
        private void generateNewDefHeroes()
        {
            actualMapOfGame.addHero(characterController.generateDefElf());
            actualMapOfGame.addHero(characterController.genereteDefDwarf());
            actualMapOfGame.addHero(characterController.genereteDefHuman());
            actualMapOfGame.addHero(characterController.genereteDefHuman2());
            actualMapOfGame.addVillan(characterController.genereteDefMonster1());
            actualMapOfGame.addVillan(characterController.genereteDefMonster3());
            actualMapOfGame.addVillan(characterController.genereteDefMonster2());
            actualMapOfGame.addVillan(characterController.genereteDefMonster4());
        }
    }
}
