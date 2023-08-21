﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Projectiles.Other
{
    public class PorcelainFriendly : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Porcelain");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 2;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            Main.EntitySpriteDraw(texture, Projectile.position, texture.Frame(1, 6), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            return true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 0;
            }
            else if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 1;
            }
            else if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 2;
            }
            else if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 3;
            }
            else if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 4;
            }
            else if (Main.rand.Next(100) < 50)
            {
                Projectile.frame = 5;
            }
            else
            {
                Projectile.frame = 0;
            }

            Projectile.timeLeft = Main.rand.Next(1000, 1200);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = true;
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 7; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust dust1 = Dust.NewDustPerfect(Projectile.Center, DustID.PinkCrystalShard, speed * 8, Scale: 1f);
                dust1.noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
        }
    }
}
