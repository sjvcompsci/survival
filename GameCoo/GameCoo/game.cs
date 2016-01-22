using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoo
{
    class Program
    {
        static void Main(string[] args)
        {
            //hello

            var game = new Game("Waifu", 640,640,60);
            
            game.Color = new Color(0.3f, 0.5f, 0.7f);


            game.Start(new Fight());
        }
    }
}   


