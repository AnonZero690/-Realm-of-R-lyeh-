using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Buffs;
using RealmOne.Items.Misc.EnemyDrops;

namespace RealmOne.Items.Accessories
{
    public class MidnightHunterOptics : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Midnight Hunter Optics"); 
            /* Tooltip.SetDefault("'A necessity when hunting at night'"
                 + "\nHunter and Nightowl affects"
                 +"\n+5% increased crit chance"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 1;
            Item.accessory = true;



        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

          player.AddBuff(ModContent.BuffType<OpticBuff>(), 60);



        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FleshyCornea>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ImpactTech>(), 5);
            recipe.AddIngredient(ItemID.Lens, 2);

            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }

    }
}