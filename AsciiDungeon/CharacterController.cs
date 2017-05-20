using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class CharacterController
    {



        public Character generateDefElf()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(40, 4)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(70, 30)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(60, 15)));
            return new Character("A", skills, 100, "elf");
        }

        public Character genereteDefDwarf()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("B", skills, 80, "krasnolud");
        }
        public Character genereteDefHuman()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("C", skills, 120, "czlowiek");
        }
        public Character genereteDefHuman2()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(50, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 40)));
            return new Character("D", skills, 100, "czlowiek");
        }
        public Character genereteDefMonster1()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(60, 7)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 50)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(43, 40)));
            return new Character("E", skills, 100, "potwor");
        }
        public Character genereteDefMonster2()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(70, 24)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(20, 30)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(45, 45)));
            return new Character("F", skills, 100, "potwor");
        }
        public Character genereteDefMonster3()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(15, 34)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(20, 60)));
            return new Character("G", skills, 100, "potwor");
        }
        public Character genereteDefMonster4()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill("Atak Wrecz", new SkillEffect(78, 14)));
            skills.Add(new Skill("Atak Łukiem", new SkillEffect(10, 20)));
            skills.Add(new Skill("Atak nozem", new SkillEffect(72, 90)));
            return new Character("H", skills, 100, "potwor");
        }
    }
}
