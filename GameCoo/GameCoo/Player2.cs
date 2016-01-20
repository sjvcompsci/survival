using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoo
{
    class Player2 : Entity
    {
        public Player1 p1;
        public int health = 100;
        public float MoveSpeed = 3;

        Spritemap<Animation> spritemap2 = new Spritemap<Animation>("Attacker1.png", 24, 40);
        public Player2(float x, float y) : base(x, y)
        {
            spritemap2.Add(Animation.WalkUp, "4", 1);
            spritemap2.Add(Animation.WalkDown, "1", 1);
            spritemap2.Add(Animation.WalkRight, "10", 1);
            spritemap2.Add(Animation.WalkLeft, "7", 1);
            spritemap2.Add(Animation.Attack, "28, 1", 15).NoRepeat();
            spritemap2.CenterOrigin();
            spritemap2.Play(Animation.WalkDown);
            AddGraphic(spritemap2);
        }
        public override void Update()
        {
            if (X <= 20)
            {
                X = 20;
            }
            if (X >= Game.Width)
            {
                X = Game.Width;
            }
            if (Y >= Game.Height)
            {
                Y = Game.Height;
            }
            if (Y <= 0)
            {
                Y = 0;
            }
            
            base.Update();
            if (Input.KeyDown(Key.Up))
            {
                spritemap2.Play(Animation.WalkUp);
                Y -= MoveSpeed;
            }
            if (Input.KeyDown(Key.Down))
            {
                spritemap2.Play(Animation.WalkDown);
                Y += MoveSpeed;
            }
            if (Input.KeyDown(Key.Left))
            {
                spritemap2.Play(Animation.WalkLeft);
                X -= MoveSpeed;
            }
            if (Input.KeyDown(Key.Right))
            {
                spritemap2.Play(Animation.WalkRight);
                X += MoveSpeed;
            }
            if (Input.KeyPressed(Key.PageUp))
            {
                spritemap2.Play(Animation.Attack);

            }

        }
    }
}
