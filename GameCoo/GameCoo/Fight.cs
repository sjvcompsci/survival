using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace GameCoo
{
    class Fight : Scene
    {

        Player1 player1 = new Player1(20, 400);
        Player2 player2 = new Player2(400, 400);

        Image blp1;
        Image lp1;
        Image blp2;
        Image lp2;
        public Fight()
        {
            blp1 = Image.CreateRectangle(100, 20, Color.Red);
            lp1 = Image.CreateRectangle(player1.gethealth, 20, Color.Green);
            blp2 = Image.CreateRectangle(100, 20, Color.Red);
            lp2 = Image.CreateRectangle(player1.gethealth, 20, Color.Green);

            AddGraphic(new Text("Hitpoints", 14));
            AddGraphic(new Text("Hitpoints", 14), 520, 0);
            AddGraphic(blp1, 0, 30);
            AddGraphic(lp1, 0, 30);
            AddGraphic(blp2, 520, 30);
            AddGraphic(lp2, 520, 30);

            Add(player1);
            Add(player2);


        }
        public override void Update()
        {
            base.Update();

            if(player1.isattack == true)
            {
                player2.gethealth -= 1;
            }
            if(player2.isattack == true)
            {
                player1.gethealth -= 1;
            }


            if (player1.gethealth != 100)
            {
                RemoveGraphic(lp1);
                lp1 = Image.CreateRectangle(player1.gethealth, 20, Color.Green);
                AddGraphic(lp1, 0, 30);
            }
            if (player1.gethealth <= 0)
            {
                Game.SwitchScene(new Death(1));
            }

            if (player2.gethealth != 100)
            {
                RemoveGraphic(lp2);
                lp2 = Image.CreateRectangle(player1.gethealth, 20, Color.Green);
                AddGraphic(lp2, 400, 30);
            }
            if (player2.gethealth <= 0)
            {
                Game.SwitchScene(new Death(2));
            }


        }
        class Death : Scene
        {
            public Death(int player)
            {
                if(player == 1)
                {
                    AddGraphic(new Text("Player 2 WINS!!! GAME OVER!", 40));
                }
                else
                {
                    AddGraphic(new Text("Player 1 WINS!!! GAME OVER!", 40));

                }
            }
        }
    }
}

