using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoo
{
    class Player1 : Entity
    {
        public Player2 p2;
        public int health = 100;

        public float MoveSpeed = 3;

        Spritemap<Animation> spritemap = new Spritemap<Animation>("character.png", 40, 38);

        public Player1(float x, float y) : base(x, y)
        {
            spritemap.Add(Animation.WalkUp, "13", 1);
            spritemap.Add(Animation.WalkRight, "9", 1);
            spritemap.Add(Animation.WalkDown, "0", 1);
            spritemap.Add(Animation.WalkLeft, "5", 1);
            spritemap.Add(Animation.Attack, "17, 0", 15).NoRepeat();
            spritemap.CenterOrigin();
            spritemap.Play(Animation.WalkDown);
            AddGraphic(spritemap);
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
            if (Input.KeyDown(Key.W))
            {
                spritemap.Play(Animation.WalkUp);
                Y -= MoveSpeed;
            }
            if (Input.KeyDown(Key.S))
            {
                spritemap.Play(Animation.WalkDown);
                Y += MoveSpeed;
            }
            if (Input.KeyDown(Key.A))
            {
                spritemap.Play(Animation.WalkLeft);
                X -= MoveSpeed;
            }
            if (Input.KeyDown(Key.D))
            {
                spritemap.Play(Animation.WalkRight);
                X += MoveSpeed;
            }
            if (Input.KeyDown(Key.Space))
            {
                spritemap.Play(Animation.Attack);
            }
            if (Input.KeyDown(Key.Space) && )
            {

            }
            
        }
    }
}
