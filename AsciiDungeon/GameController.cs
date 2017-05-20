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
                enteredCommand = Console.ReadLine();
                switch (enteredCommand)
                {
                    case definsCommands.commnadForHelp:
                        UI.printAllCommands();
                        break;

                    default:
                        break;
                }
            }while (!enteredCommand.Equals(definsCommands.commandForGameExit));
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
