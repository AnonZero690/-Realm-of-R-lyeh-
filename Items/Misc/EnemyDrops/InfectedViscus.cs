using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items.Misc.EnemyDrops
{
    public class InfectedViscus : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infected Viscus"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Infected organs of the vile creatures of the corruption");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


        }

        public override void SetDefaults()
        {
            
            Item.width = 20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = 3;
            Item.maxStack = 999;

        }




    }
}