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
        int health = 100;
        public float MoveSpeed = 3;
        bool attack = false;

        BoxCollider c = new BoxCollider(24, 40, Tag.P2);
        Spritemap<Animation> spritemap2 = new Spritemap<Animation>("Attacker1.png", 24, 40);

        public bool isattack
        {
            get { return attack; }
        }

        public int gethealth
        {
            get { return health; }
            set { health = value; }
        }
        public float getX
        {
            get { return X; }
        }
        public float getY
        {
            get { return Y; }
        }




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
            AddCollider(c);
            c.CenterOrigin();
        }
        public override void Update()
        {
            if (X <= 15)
            {
                X = 15;
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
           if (Input.KeyDown(Key.PageUp) && c.Overlap(X, Y, Tag.P1))
            {
                attack = true;
                    attack = false;
            }
           
        }
        public override void Render()
        {
            base.Render();
            c.Render();



        }
    }
}
