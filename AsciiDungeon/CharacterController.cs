using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class CharacterController
    {

        public bool attack(string command, Map mapOfGame)
        {
            string newCommand = command.Remove(0, (definsCommands.commandForAttack.Length + 1));
            newCommand = newCommand.Remove(newCommand.Length-1, 1);   //usuwa zamkniecie nawiasu
            string[] newCommandSplitted = newCommand.Split(',');
            //foreach (var val in newCommandSplitted)
            //    UI.printText(val);
            if (newCommandSplitted.Length != 3)
            {
                UI.printMessege($"Niepoprawna komenda\nWzor poprawnej komendy: {definsCommands.rightAttackCommand}\nAby kontynuowac nacisnij <ENTER>");
                return false;
            }
            int heroNumber, villanNumber, skill = 0;
            if (!(Int32.TryParse(newCommandSplitted[0], out heroNumber) && Int32.TryParse(newCommandSplitted[1], out villanNumber) && Int32.TryParse(newCommandSplitted[2], out skill)))
            {
                UI.printMessege($"Niepoprawna komenda\nWzor poprawnej komendy: {definsCommands.rightAttackCommand} -> wszystkie wartosci powinny byc liczbami calkowitymi\nAby kontynuowac nacisnij <ENTER>");
                return false;
            }

            //blok dzialania skilla
            Character hero = mapOfGame.listOfPositionsOfHeroes[heroNumber].getChararcterOnPosition();
            Character villan = mapOfGame.listOfPositionsOfVillans[heroNumber].getChararcterOnPosition();
            int helpHealth = villan.stats.health;
            UI.printAttackSequence(hero, villan, skill);
            if(attackSequence(hero, villan, skill))
            {
                UI.printMessege($"Udalo sie!\n{villan.nameOfCharacter} poniosl obrazenia w wysokosci {helpHealth-villan.stats.health}");
                return true;
            }else
            {
                UI.printMessege("Pudlo!");
                return false;
            }
        }


        public bool attackSequence( Character attacer, Character defender, int skillNumber)
        {
            Random r = new Random();
            if(r.Next(0, 100) > attacer.listOfSkills[skillNumber].skillEffect.chanceOfSucces)
            {//nie udalo sie
                return false;
            }else
            {//udalo sie
                defender.getDamage((attacer.listOfSkills[skillNumber].skillEffect.damege*(attacer.stats.strength/10))-(defender.stats.defence/5)); //(dmg*sila/10)-obrona/5
                return true;
            }
        }

        public bool move(string command, Map mapOfGame)
        {
            return true;
        }
        






        // Jakieś defaultowe postacie - narazie wystarczy :P
        public Character generateDefElf()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(40, 4)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(70, 30)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(60, 15)));
            return new Character("A", skills, "elf", new StatisticsOfCharacter(100, 40, 70, 30));
        }

        public Character genereteDefDwarf()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("B", skills, "krasnolud", new StatisticsOfCharacter(120, 80, 40, 60));
        }
        public Character genereteDefHuman()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("C", skills, "czlowiek", new StatisticsOfCharacter(110, 65, 56, 45));
        }
        public Character genereteDefHuman2()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("D", skills, "czlowiek", new StatisticsOfCharacter(100,45,54,34));
        }
        public Character genereteDefMonster1()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(60, 7)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 50)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(43, 40)));
            return new Character("E", skills, "potwor", new StatisticsOfCharacter(100, 110, 2, 45));
        }
        public Character genereteDefMonster2()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(70, 24)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(20, 30)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(45, 45)));
            return new Character("F", skills, "potwor", new StatisticsOfCharacter(120, 11, 43, 70));
        }
        public Character genereteDefMonster3()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(15, 34)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(20, 60)));
            return new Character("G", skills, "potwor", new StatisticsOfCharacter(80, 91, 23, 70));
        }
        public Character genereteDefMonster4()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(78, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 90)));
            return new Character("H", skills, "potwor", new StatisticsOfCharacter(130, 112, 3, 40));
        }
    }
}
