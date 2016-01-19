using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteMapStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //hello
            var game = new Game("Spritemap Animation", 400, 200);
            game.SetWindowScale(3);
            game.Color = new Color(0.3f, 0.5f, 0.7f);
            var scene = new Scene();
            scene.Add(new AnimatingEntity(game.HalfWidth, game.HalfHeight));
            game.Start(scene);
        }
    }
    class AnimatingEntity : Entity
    {
        public float MoveSpeed = 3;
        enum Animation
        {
            WalkUp,
            WalkDown,
            WalkLeft,
            WalkRight,
            Attack
        }
        Spritemap<Animation> spritemap2 = new Spritemap<Animation>("Attacker1.png", 24, 40);
        Spritemap<Animation> spritemap = new Spritemap<Animation>("character.png", 40, 38);
        public AnimatingEntity(float x, float y) : base(x, y)
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
            if(X >= Game.Width)
            {
                X = Game.Width;
            }
            if(Y >= Game.Height)
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
            if (Input.KeyPressed(Key.Space))
            {
                spritemap.Play(Animation.Attack);

            }
         
            }
        }
    }

