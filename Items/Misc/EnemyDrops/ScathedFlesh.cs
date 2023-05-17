using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items.Misc.EnemyDrops
{
    public class ScathedFlesh : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scathed Flesh"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Ripped off the body from the blood hungry creatures of the crimson");
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