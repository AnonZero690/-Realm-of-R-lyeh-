﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmOne;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using RealmOne.Projectiles;
using Terraria.Localization;
using Terraria.Audio;
using RealmOne.Common.Systems;
using RealmOne.Items.Ammo;
using RealmOne.Items;
using RealmOne.Armor;

namespace RealmOne.Armor
{
    [AutoloadEquip(EquipType.Body)]

    public class PiggyBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Piggy Patroller Bodyplate");
            /* Tooltip.SetDefault("5% increased knockback but 8% decreased movement speed"
                +"\nDiscount on all Shop Items!"
                +"\n'Carrying a heavy bodyplate full of porcelain'"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Blue; // The rarity of the item
            Item.defense = 5; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetKnockback(DamageClass.Generic) += 0.05f;
            player.moveSpeed -= 0.08f;
            player.discountAvailable = true;

        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect


        // UpdateArmorSet allows you to give set bonuses to the armor.


        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
           
            .AddIngredient(Mod,"PiggyPorcelain", 6)
            .AddTile(TileID.Furnaces)
            .Register();


        }
    }
}
