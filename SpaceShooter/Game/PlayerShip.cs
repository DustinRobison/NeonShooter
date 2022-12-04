using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SpaceShooter
{
    internal class PlayerShip : Entity
    {
        private static PlayerShip instance;
        const int cooldownFrames = 6;
        int cooldownRemaining = 0;
        static Random rand = new Random();

        public static PlayerShip Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerShip();

                return instance;
            }
        }

        private PlayerShip()
        {
            image = Art.Player;
            Position = GameRoot.ScreenSize / 2;
            Radius = 10;
        }

        public override void Update()
        {
            // ship logic goes here
            const float speed = 8;
            Velocity = speed * Input.GetMovementDirection();
            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);

            if (Velocity.LengthSquared() > 0)
                Orientation = Velocity.ToAngle();

            // Bullets
            var aim = Input.GetAimDirection();
            if (aim.LengthSquared() > 0 && cooldownRemaining <= 0)
            {
                // Fire Bullet
                cooldownRemaining = cooldownFrames;
                float aimAngle = aim.ToAngle();
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                float randomSpread = rand.NextFloat(-0.04f, 0.04f) + rand.NextFloat(-0.04f, 0.04f);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);

                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);
                EntityManager.Add(new Bullet(Position + offset, vel));

                offset = Vector2.Transform(new Vector2(25, 8), aimQuat);
                EntityManager.Add(new Bullet(Position + offset, vel));
            }

            if (cooldownRemaining > 0)
                cooldownRemaining--;
        }
    }
}
