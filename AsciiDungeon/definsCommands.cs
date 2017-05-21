using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    static class definsCommands
    {
        public const string commandForGameExit = "game --exit";
        public const string commnadForHelp = "help";


        //Sterowanie Postaciami---------------------------------------------------
        //Poprawny attack: attack(kto>,<kogo>,<czym>)
        public const string rightAttackCommand = @"attack(<kto>,<kogo>,<czym>)";
        public const string commandForAttack = "attack";
        //poprawny move: move(<kto>,<gdzie>)
        public const string rightMoveCommand = @"move(<kto>,<gdzie>)";
        public const string commandForMove = "move";

        public const string rightUseItemCommand = @"use(<kto>,<co>)";
        public const string commandForUseItem = @"use";
        

    }
}
