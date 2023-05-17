using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;

namespace RealmOne.Buffs.Alc
{
    public class WineBuff : ModBuff
    {
        public override void SetStaticDefaults()


        {
            // DisplayName.SetDefault("Spicegrass Vodka");
            // Description.SetDefault("Drink too much and you'll be drunk");
           

        }


        public override void Update(Player player, ref int buffIndex)
        {

            player.runAcceleration += 0.08f;
            player.statDefense -= 2;
            player.moveSpeed += 0.08f;

        }




    }
}