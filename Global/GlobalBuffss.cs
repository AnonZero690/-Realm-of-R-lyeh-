using RealmOne.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Global
{
    // Showcases how to work with all buffs
    public class GlobalBuffss : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Thorns)
            {
                player.GetModPlayer<ThornsPlayer>().thornsPoison = true;


            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
        {
            // Make the campfire buff have a different color and shake slightly
            if (type == ModContent.BuffType<HazardBuff>())
            {


                Vector2 shake = new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3));

                drawParams.Position += shake;
                drawParams.TextPosition += shake;
            }
            return true;
        }


        
    }
    public class ThornsPlayer : ModPlayer
    {
        public bool thornsPoison = false;

        public override void ResetEffects()
        {
            thornsPoison = false;
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using OnHitNPC instead */
        {
            if (thornsPoison)
            {
                target.AddBuff(BuffID.Poisoned, 600); // Apply Poison debuff for 2 seconds
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Projectile, consider using OnHitNPC instead */
        {
            if (thornsPoison)
            {
                target.AddBuff(BuffID.Poisoned, 600); // Apply Poison debuff for 2 seconds
            }
        }
        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {

            if (thornsPoison)
            {
                npc.AddBuff(BuffID.Poisoned, 600); // Apply Poison debuff for 2 seconds
            }
        }
    }

}