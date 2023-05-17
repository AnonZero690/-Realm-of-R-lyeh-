using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items.Accessories
{
    public class RoyalRawhide : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Rawhide"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("5% increased acceleration and movement speed"
            + "\n4 defense"
            + "\nWhen you are hit by an enemy you are granted a slime dash buff"
            + "\nThe buff cannot be stacked, as soon as your hit, the buff will last for 4 seconds"
            + "\nThis dash has a 8 second cooldown");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 32;
            Item.height = 32;
            Item.value = 10000;
            Item.rare = -12;
            Item.accessory = true;
            Item.defense += 4;
            Item.masterOnly = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.05f;
            player.accRunSpeed += 0.05f;


        }

    }
}