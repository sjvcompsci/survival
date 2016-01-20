using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoo
{
    class gameScene : Scene
    {
        private Player1 p1;
        private Player2 p2;
        public gameScene()
        {
            p1 = new Player1(400, 100);
            p2 = new Player2(100,100);
            Add(p1);
            Add(p2);
            p1.p2 = p2;
            p2.p1 = p1;

            
        }
    }
}
