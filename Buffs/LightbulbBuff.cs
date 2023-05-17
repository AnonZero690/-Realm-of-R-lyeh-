using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RealmOne.Projectiles.Magic;
using ReLogic.Content;

using static Terraria.ModLoader.ModContent;
using System;

namespace RealmOne.Buffs
{
    public class LightbulbBuff : ModBuff
    {


        public override void SetStaticDefaults()


        {
            // DisplayName.SetDefault("Lightbulb Buff");
            // Description.SetDefault("'You are a lightbulb!'");
           

        }


        public override void Update(Player player, ref int buffIndex)
        {
            if (player.active) // Check if the player is still active
            {

                Lighting.AddLight(player.position, 2f, 1f, 0.3f);


                if (player.ZoneNormalUnderground)
                {
                    Lighting.AddLight(player.position, 3f, 1.5f, 0.6f);
                }

                if (player.ZoneNormalCaverns)
                {
                    Lighting.AddLight(player.position, 3f, 1.5f, 0.6f);
                }
            }
            
        }

        
    }


}