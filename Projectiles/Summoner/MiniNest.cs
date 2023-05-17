using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using RealmOne.Common.Systems;
using RealmOne.Common.DamageClasses;
using RealmOne.Projectiles.Magic;
using RealmOne.Projectiles.Summoner;
using RealmOne.NPCs.Critters;
using RealmOne.NPCs.Enemies;

namespace RealmOne.Projectiles.Summoner
{
    public class MiniNest : ModProjectile
    {



        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Antlion Nest");

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;

        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.scale = 0.6f;

       
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.1f;

            Projectile.tileCollide = true;
            Projectile.timeLeft = 400;
            Projectile.extraUpdates = 2;
            Projectile.CloneDefaults(ProjectileID.Shuriken);

        }

        public override void AI()
        {

            Projectile.rotation += 0.05f * Projectile.velocity.X;
            Projectile.velocity.Y += 0.2f;

            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.DesertPot, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, Scale: 1f);



        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
           
           // Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<MiniAnti>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
         //   NPC.NewNPC(Terraria.Entity.GetSource_None(), ModContent.NPCType<Anti>(),Projectile.damage, Main.myPlayer);

            return true;

        }

        

        public override bool? CanHitNPC(NPC target) => !target.friendly;
        public override void Kill(int timeLeft)
        {

        //    NPC.NewNPC(Terraria.Entity.GetSource_None(), ModContent.NPCType<Anti>(), Projectile.damage, Main.myPlayer);
            // Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<MiniAnti>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
            SoundEngine.PlaySound(SoundID.NPCDeath35, Projectile.position);

            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Sand, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }

            int dustIndex1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 210, 0f, 0f, 255, default, 1.5f);

            Main.dust[dustIndex1].noGravity = true;
            Main.dust[dustIndex1].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
            Main.dust[dustIndex1].noLight = true;
        }
    }
}





