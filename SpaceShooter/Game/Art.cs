using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class Art
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D Seeker { get; private set; }
        public static Texture2D Wanderer { get; private set; }
        public static Texture2D Bullet { get; private set; }
        public static Texture2D Pointer { get; private set; }


        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Art/Player");
            Seeker = content.Load<Texture2D>("Art/Seeker");
            Wanderer = content.Load<Texture2D>("Art/Wanderer");
            Bullet = content.Load<Texture2D>("Art/Bullet");
            Pointer = content.Load<Texture2D>("Art/Pointer");
        }
    }
}
