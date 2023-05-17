using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RealmOne.Projectiles.Throwing;
using Terraria.Audio;
using RealmOne.Buffs;

namespace RealmOne.Items.Accessories
{
    public class Peni : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Penicillin"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            /* Tooltip.SetDefault($"[c/00FF00:Sub Accessory]"
                + "\n'10+HP, Immunity to poison, venom, bleeding'" +
                "\nWhen hit, you regen health 2x faster" +
                "\nRight click to consume it." +
                "\nBuffs are now 2x Stronger (20+HP)"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 2;
            Item.accessory = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 35;
            Item.useAnimation = 35;
        }
       
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {

                Item.useStyle = ItemUseStyleID.DrinkLiquid;
                Item.useTime = 14;
                Item.useAnimation = 14;


                Item.shoot = ProjectileID.None;
                Item.value = 500;
                Item.rare = 2;
                Item.consumable = true;
                
                Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/LightbulbShine");

                Item.buffType = BuffID.Swiftness ;
                Item.buffTime = 300;
            }
            else
            {

                Item.useStyle = ItemUseStyleID.Swing;
                Item.useTime = 35;
                Item.useAnimation = 35;
                Item.consumable = true;
                Item.width = 20;
                Item.height = 20;
                Item.value = 10000;
                Item.rare = 2;
                Item.accessory = true;
            }
                return base.CanUseItem(player);
       }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.statLifeMax2 += 10;

            

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.AddIngredient(Mod,"GoopyGrass", 2);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
            
        }
    }
}