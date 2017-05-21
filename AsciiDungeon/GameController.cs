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
        private AI thoseMotherFckMonstersAreGettingMoreAndMoreInteligence { get; set; }
        private String enteredCommand { get; set; }
        private enum commands
        {
            exit, attack, move, options, def, help, use
        }

        private enum gameStatus
        {
            lost, win, still
        }

        public GameController()
        {
            actualMapOfGame = new Map();
            characterController = new CharacterController();
            thoseMotherFckMonstersAreGettingMoreAndMoreInteligence = new AI();
        }

        //----------------------------Rozpoczecie nowej gry
        public void startNewGame()
        {
            
            UI.printHelloMessege();
            generateNewDefHeroes();
            try
            {
                mainLoop();
            }catch(Exception e)
            {
                UI.printFailMessege(e);
            }
        }

        private void mainLoop()
        {
            gameStatus endOfGame = gameStatus.still;
            bool enteredEndOfGame = false;
            do
            {
                endOfGame = checkIfGameHasEndeed(actualMapOfGame);
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
                        if (characterController.attack(enteredCommand, actualMapOfGame))
                            thoseMotherFckMonstersAreGettingMoreAndMoreInteligence.aiMove(actualMapOfGame);
                        else
                            goto writeCommandAgain;
                        break;

                    case commands.move:
                        if (characterController.move(enteredCommand, actualMapOfGame))
                            thoseMotherFckMonstersAreGettingMoreAndMoreInteligence.aiMove(actualMapOfGame);
                        else
                            goto writeCommandAgain;
                        break;

                    case commands.exit:
                        enteredEndOfGame = true;
                        break;

                    case commands.use:
                        if (characterController.useItem(enteredCommand, actualMapOfGame))
                            thoseMotherFckMonstersAreGettingMoreAndMoreInteligence.aiMove(actualMapOfGame);
                        else
                            goto writeCommandAgain;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna komenda\nWpisz <help> by uzyskac liste wszystkich komend");
                        goto writeCommandAgain;
                }
            }while (endOfGame==gameStatus.still || !enteredEndOfGame);

            switch (endOfGame)
            {
                case gameStatus.lost:
                    UI.printLostMessege();
                    break;

                case gameStatus.win:
                    UI.printWinMessege();
                    break;

                default:
                    UI.printFailMessege(null);
                    break;
            }
        }

        private gameStatus checkIfGameHasEndeed(Map mapOfGame)
        {
            if (!mapOfGame.listOfPositionsOfHeroes.Any(x => x.getChararcterOnPosition().isAlive))       //jak przegrana
                return gameStatus.lost;
            else
                if (!mapOfGame.listOfPositionsOfVillans.Any(x => x.getChararcterOnPosition().isAlive))  //jak wygrana
                return gameStatus.win;
            else
                return gameStatus.still;                                                                //gramy dalej
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
            if (enteredCommand.Contains(definsCommands.commandForUseItem))
                return commands.use;
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
            Item smallHealPotion = new Item("Mala misktura lecznicza", 20, 0);
            Item largelHealPotion = new Item("Duza misktura lecznicza", 50, 0);
            Item smallDefencePotion = new Item("Mala misktura wzmocnienia obrony", 0, 5);
            foreach(var val in actualMapOfGame.listOfPositionsOfHeroes)
            {
                val.getChararcterOnPosition().grantItem(smallHealPotion);
                val.getChararcterOnPosition().grantItem(largelHealPotion);
                val.getChararcterOnPosition().grantItem(smallDefencePotion);
            }
            foreach (var val in actualMapOfGame.listOfPositionsOfVillans)
            {
                val.getChararcterOnPosition().grantItem(smallHealPotion);
                val.getChararcterOnPosition().grantItem(largelHealPotion);
                val.getChararcterOnPosition().grantItem(smallDefencePotion);
            }
        }
    }
}
