using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static RealmOne.RealmPlayer.RealmModPlayer;
using RealmOne.Items.Weapons.Ranged;

namespace RealmOne.Items.Accessories
{
    public class EarthEmerald : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Earth Emerald"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            /* Tooltip.SetDefault("'If the Earth was shrunk into a gem'"
              + "\n15% increased tool and weapon speed"
              + "\nSpelunker, Night Owl, Shine buffs"
              + "\nThese stats are better in the day"); */




            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.accessory = true;
            Item.masterOnly = true;
            Item.master = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.findTreasure = true;
            Lighting.AddLight(player.position, 1.2f, 1.1f, 0.4f);

            if (Main.dayTime)
            {
                player.pickSpeed -= 0.20f; // Increase pickaxe speed by 20%
               player.GetAttackSpeed(DamageClass.Generic) += 0.20f;
                player.nightVision = true;
            }

            else

            {
                player.GetDamage(DamageClass.Generic) += 0.15f;
                player.pickSpeed -= 0.15f; // Increase pickaxe speed by 20%
                player.GetAttackSpeed(DamageClass.Generic) += 0.15f;
                player.nightVision = true;
            }
            return;
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
        
            if (player.HeldItem.ModItem != null && player.HeldItem.ModItem.Mod == Mod && player.HeldItem.type == ModContent.ItemType<TommyGun>()) ;
            {
                Item.damage += 20; // Increase the damage of your modded weapon by 20%
            }
        }
    
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();



            Recipe balls = CreateRecipe();
            balls.AddIngredient(ItemID.Bone, 25);
            balls.AddIngredient(ItemID.DemoniteBar, 10);
            balls.AddIngredient(ItemID.Chain, 2);
            balls.AddTile(TileID.Anvils);
            balls.Register();
        }






    }
}