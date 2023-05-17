using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;

namespace RealmOne.Buffs.Alc
{
    public class BeerBuff : ModBuff
    {
        public override void SetStaticDefaults()


        {
            // DisplayName.SetDefault("Limetwist Rum");
            // Description.SetDefault("Drink too much and you'll be drunk");
           

        }


        public override void Update(Player player, ref int buffIndex)
        {

            player.endurance *= 0.1f;
            player.GetAttackSpeed(DamageClass.Generic) -= 0.17f;
            player.GetArmorPenetration(DamageClass.Generic) += 3f;

        }




    }
}