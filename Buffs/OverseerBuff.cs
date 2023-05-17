using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;

namespace RealmOne.Buffs
{
    public class OverseerBuff : ModBuff
    {
        public override void SetStaticDefaults()


        {
            DisplayName.SetDefault("Overseer Buff");
            Description.SetDefault("Increases crit chance by 4%+. Stack up to 5 times");


        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Generic) += 4f;

        }


    }


}