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
        public GameController()
        {
            actualMapOfGame = new Map();
            characterController = new CharacterController();
        }
        public void startNewGame()
        {
            UI.printHelloMessege();
            Console.Clear();
            generateNewDefHeroes();
            UI.printOnConsoleMapStatus(actualMapOfGame);

            Console.ReadKey();
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
