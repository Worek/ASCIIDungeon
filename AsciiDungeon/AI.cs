using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class AI
    {



        public bool aiMove(Map actualMapOfGame)
        {
            Node root = new AINode(new Map(actualMapOfGame), 0, new Move(0, 0, 0, 0,-1));
            root.generateNodes();
            float markOfMoveToDo = root.evaluate();
            Move moveToDo = root.listOfLeafs.Find(x => x.move.mark == markOfMoveToDo).move;
            if (moveToDo.itemNumber == -1)
            {
                Character attacker = actualMapOfGame.listOfPositionsOfVillans[moveToDo.villanPosition].getChararcterOnPosition();
                Character enemy = actualMapOfGame.listOfPositionsOfHeroes[moveToDo.heroPosition].getChararcterOnPosition();
                int helpHealth = enemy.stats.health;
                UI.printAttackSequence(attacker, enemy, moveToDo.skillNumber, "Ruch Przeciwnika");
                if(CharacterController.attackSequence(attacker, enemy, moveToDo.skillNumber))
                {
                    UI.printMessege($"Udalo sie!\n{enemy.nameOfCharacter} poniosl obrazenia w wysokosci {helpHealth - enemy.stats.health}");
                    return true;
                }
                else
                {
                    UI.printMessege("Pudlo!");
                    return true;
                }
            }
            else
            {
                Character hero = actualMapOfGame.listOfPositionsOfVillans[moveToDo.villanPosition].getChararcterOnPosition();

                hero.useItem(hero.itemList[moveToDo.itemNumber]);
                if (hero.itemList[moveToDo.itemNumber].healthEffect != 0)
                    UI.printMessege($"{hero.nameOfCharacter} odnowil {hero.itemList[moveToDo.itemNumber].healthEffect} pkt zdrowia");
                if (hero.itemList[moveToDo.itemNumber].defenceEffect != 0)
                    UI.printMessege($"{hero.nameOfCharacter} dostal {hero.itemList[moveToDo.itemNumber].defenceEffect} pkt do obrony");

                hero.itemList.RemoveAt(moveToDo.itemNumber);
            }
            return true;
        }


    }
    public class Move
    {
        public int villanPosition;
        public int heroPosition;
        public int skillNumber;
        public int itemNumber;
        public float mark;

        public Move(int v, int h, int s, float m, int i)
        {
            this.villanPosition = v;
            this.heroPosition = h;
            this.mark = m;
            this.skillNumber = s;
            this.itemNumber = i;
        }
    }

    class Node
    {
        public Move move { get; set; }
        public Map ownMap { get; private set; }
        public List<Node> listOfLeafs { get; private set; }
        public Node parent { get; private set; }
        public int positionUsedInMove { get; private set; }
        public int skillUsedInMove { get; private set; }
        public int levelOfTree { get; private set; }


        public Node(Map map, int lvl, Move move, Node parent = null)
        {
            this.ownMap = map;
            this.parent = parent;
            this.levelOfTree = lvl;
            this.move = move;
            listOfLeafs = new List<Node>();
        }
        protected float markFunctionAfterAttack(Map mapOfGame, int skillChance)
        {
            int heroHealth = 0;
            int villanHealth = 0;
            foreach (var val in mapOfGame.listOfPositionsOfHeroes)
                heroHealth += val.getChararcterOnPosition().stats.health;
            foreach (var val in mapOfGame.listOfPositionsOfVillans)
                villanHealth += val.getChararcterOnPosition().stats.health;
            return (villanHealth - heroHealth) * (skillChance / 100);                 //<<<------------- FUNKCJA OCENY KURDE!
        }

        protected float markFunctionAfterItem(Map mapOfGame)
        {
            int heroHealth = 0;
            int villanHealth = 0;
            foreach (var val in mapOfGame.listOfPositionsOfHeroes)
                heroHealth += val.getChararcterOnPosition().stats.health;
            foreach (var val in mapOfGame.listOfPositionsOfVillans)
                villanHealth += val.getChararcterOnPosition().stats.health;
            return (villanHealth - heroHealth);
        }

        virtual public float evaluate() { return 0.0F; }





        virtual public void generateNodes() { }
    }

    class AINode : Node
    {
        public AINode(Map map, int lvl, Move move, Node parent = null) : base(map, lvl, move, parent)
        {
        }

        override public void generateNodes()
        {
            if (this.levelOfTree >= Options.treeDepth)
            {
                //to co będzie po generowaniu
            }
            else
            { //GENEROWANIE PODDRZEW -> O NA BOGA ILE TEGO :D
                foreach (var character in ownMap.listOfPositionsOfVillans)
                {
                    if (character.getChararcterOnPosition().isAlive)
                    {
                        foreach (var skill in character.getChararcterOnPosition().listOfSkills)
                        {
                            foreach (var enemy in ownMap.listOfPositionsOfHeroes)
                            {
                                listOfLeafs.Add(attackMove(ownMap, character.numberOfPosition, enemy.numberOfPosition, skill.skillNumber));
                            }
                            foreach (var item in character.getChararcterOnPosition().itemList)
                            {
                                listOfLeafs.Add(useItemMove(ownMap, character.numberOfPosition, item.positionInBag));
                            }
                        }
                    }
                }
                
            }
            foreach (var val in listOfLeafs) // niech sobie same generuja tez - rekurencja :D
                val.generateNodes();
        }

        private PlayerNode attackMove(Map mapOfGame, int characterPosition, int oponentPosition, int skillNumber)
        {
            Map newMap = new Map(mapOfGame);

            //wykonanie ruchu
            //defender.getDamage((attacer.listOfSkills[skillNumber].skillEffect.damege*(attacer.stats.strength/10))-(defender.stats.defence/2)); //(dmg*sila/10)-obrona/2
            //attackDamage(Character attacer, Character defender, int skillNumber)
            int damage = CharacterController.attackDamage(newMap.listOfPositionsOfVillans[characterPosition].getChararcterOnPosition(), newMap.listOfPositionsOfHeroes[oponentPosition].getChararcterOnPosition(), skillNumber);
            newMap.listOfPositionsOfHeroes[oponentPosition].getChararcterOnPosition().getDamage(damage);

            //Wyliczenie funkcji oceny dla ruchu (mapa, szansa skilla):
            float mark = markFunctionAfterAttack(newMap, newMap.listOfPositionsOfVillans[characterPosition].getChararcterOnPosition().listOfSkills[skillNumber].skillEffect.chanceOfSucces);

            //historia ruchu
            Move ownMove = new Move(characterPosition, oponentPosition, skillNumber, mark, -1);


            return new PlayerNode(newMap, this.levelOfTree + 1, ownMove, this);
        }

        private PlayerNode useItemMove(Map mapOfGame, int characterPosition, int itemNumber)
        {
            Map newMap = new Map(mapOfGame);

            //use item(<kto>.useItem(<co>)
            newMap.listOfPositionsOfVillans[characterPosition].getChararcterOnPosition().useItem(newMap.listOfPositionsOfVillans[characterPosition].getChararcterOnPosition().itemList[itemNumber]);
            float mark = markFunctionAfterItem(newMap);
            Move ownMove = new Move(characterPosition, -1, -1, mark, itemNumber);
            return new PlayerNode(newMap, this.levelOfTree + 1, ownMove, this);
        }

        public override float evaluate()
        {

            if (this.levelOfTree >= Options.treeDepth || this.listOfLeafs.Count() == 0)
                return this.move.mark;
            else
            {
                float newMark = listOfLeafs.First().move.mark;
                foreach (var val in listOfLeafs)
                {
                    if (val.evaluate() > newMark)
                        newMark = val.move.mark;
                }
                this.move.mark = newMark;
                return newMark;
            }
        }

        class PlayerNode : Node
        {
            public PlayerNode(Map map, int lvl, Move move, Node parent = null) : base(map, lvl, move, parent)
            {
            }

            override public void generateNodes()
            {
                if (this.levelOfTree >= Options.treeDepth)
                {
                    //to co będzie po generowaniu
                }
                else
                { //GENEROWANIE PODDRZEW -> O NA BOGA ILE TEGO :D
                    foreach (var character in ownMap.listOfPositionsOfHeroes)
                    {
                        if (character.getChararcterOnPosition().isAlive)
                        {
                            foreach (var skill in character.getChararcterOnPosition().listOfSkills)
                            {
                                foreach (var oponent in ownMap.listOfPositionsOfVillans)
                                {
                                    listOfLeafs.Add(attackMove(ownMap, character.numberOfPosition, oponent.numberOfPosition, skill.skillNumber));
                                }
                            }
                            foreach (var item in character.getChararcterOnPosition().itemList)
                            {
                                listOfLeafs.Add(useItemMove(ownMap, character.numberOfPosition, item.positionInBag));
                            }
                        }
                    }
                    
                }
                foreach (var val in listOfLeafs) // niech sobie same generuja tez - rekurencja :D
                    val.generateNodes();
            }

            private AINode attackMove(Map mapOfGame, int characterPosition, int oponentPosition, int skillNumber)
            {
                Map newMap = new Map(mapOfGame);

                //wykonanie ruchu
                //defender.getDamage((attacer.listOfSkills[skillNumber].skillEffect.damege*(attacer.stats.strength/10))-(defender.stats.defence/2)); //(dmg*sila/10)-obrona/2
                //attackDamage(Character attacer, Character defender, int skillNumber)
                int damage = CharacterController.attackDamage(newMap.listOfPositionsOfHeroes[characterPosition].getChararcterOnPosition(), newMap.listOfPositionsOfVillans[oponentPosition].getChararcterOnPosition(), skillNumber);
                newMap.listOfPositionsOfVillans[oponentPosition].getChararcterOnPosition().getDamage(damage);

                //Wyliczenie funkcji oceny dla ruchu (mapa, szansa skilla):
                float mark = markFunctionAfterAttack(newMap, newMap.listOfPositionsOfHeroes[characterPosition].getChararcterOnPosition().listOfSkills[skillNumber].skillEffect.chanceOfSucces);

                //historia ruchu
                Move ownMove = new Move(characterPosition, oponentPosition, skillNumber, mark, -1);


                return new AINode(newMap, this.levelOfTree + 1, ownMove, this);
            }

            private AINode useItemMove(Map mapOfGame, int characterPosition, int itemNumber)
            {
                Map newMap = new Map(mapOfGame);
                //use item(<kto>.useItem(<co>)
                newMap.listOfPositionsOfHeroes[characterPosition].getChararcterOnPosition().useItem(newMap.listOfPositionsOfHeroes[characterPosition].getChararcterOnPosition().itemList[itemNumber]);
                float mark = markFunctionAfterItem(newMap);
                Move ownMove = new Move(characterPosition, -1, -1, mark, itemNumber);
                return new AINode(newMap, this.levelOfTree + 1, ownMove, this);
            }

            public override float evaluate()
            {
                if (this.levelOfTree >= Options.treeDepth || this.listOfLeafs.Count()==0)
                    return this.move.mark;
                else
                {
                    float newMark = listOfLeafs.First().move.mark;
                    foreach (var val in listOfLeafs)
                    {
                        if (val.evaluate() > newMark)
                            newMark = val.move.mark;
                    }
                    this.move.mark = newMark;
                    return newMark;
                }
            }
        }
    }
}
