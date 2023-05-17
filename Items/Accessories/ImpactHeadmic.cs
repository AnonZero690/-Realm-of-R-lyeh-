using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items.Accessories
{
    public class ImpactHeadmic : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Impact Headmic"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            /* Tooltip.SetDefault("20+ increased mana"
                 + "\n6% increased magic crit and usetime when equipped"); */
                

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
            player.GetCritChance(DamageClass.Magic) += 6f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.06f;
            player.statManaMax2 += 20;




        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "ImpactTech", 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }
}