﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RealmOne.Common.Systems;
using RealmOne.Projectiles.Magic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Projectiles.Sword
{

    public class UnstableWireBladeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wireblade");
            Main.projFrames[Projectile.type] = 4;

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 120;
            Projectile.height = 70;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 24;
            Projectile.light = 1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.5f;
            }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];


            if (++Projectile.frameCounter >= 6f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Electric, Projectile.velocity.X * 0.7f, Projectile.velocity.Y * 0.7f, Scale: 0.6f, Alpha: 120) ;   //spawns dust behind it, this is a spectral light blue dust

            Vector2 swingangle = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            Projectile.rotation = swingangle.ToRotation();
            Projectile.position = player.Center + swingangle - new Vector2(Projectile.width / 2, Projectile.height / 2);

         
        }
       
      
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawPosition = Projectile.Center;
            Color color = Color.Cyan;
            _ = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

            Vector2 origin = sourceRectangle.Size() / 2f;

          //  float offsetX = 43;
         //   origin.X = Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX;

            //float offsetY = 40;
            //origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);

            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            return false;
        }
      
    }



}
