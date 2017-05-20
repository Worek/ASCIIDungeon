using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gc = new GameController();
            gc.startNewGame();
        }
    }
}
