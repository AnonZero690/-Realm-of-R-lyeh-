using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Projectiles.Summoner
{

    public class MiniAnti : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mini Ant");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 6;

        }

        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;

            
            Projectile.DamageType = DamageClass.Summon;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 300;
            Projectile.penetrate = 2;
        }

        public override void AI()
        {

            if (++Projectile.frameCounter >= 20f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }


            if (Projectile.timeLeft <= 0)
            {
                // These gores work by simply existing as a texture inside any folder which path contains "Gores/"
                int AntGore1 = Mod.Find<ModGore>("MiniAntiGore1").Type;
                int AntGore2 = Mod.Find<ModGore>("MiniAntiGore2").Type;

                var entitySource = Projectile.GetSource_Death() ;

                for (int i = 0; i < 3; i++)
                {
                    Gore.NewGore(entitySource, Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), AntGore1);
                    Gore.NewGore(entitySource,Projectile.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), AntGore2);

                }

            }

            float maxDetectRadius = 300;
            float projSpeed = 6;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;


            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
        }


        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;


            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;


            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];

                if (target.CanBeChasedBy())
                {

                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);


                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
    }
}