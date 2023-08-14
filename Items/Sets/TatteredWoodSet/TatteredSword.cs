﻿using RealmOne.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.Sets.TatteredWoodSet
{
    public class TatteredSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LeadBroadsword);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TatteredWood>(), 12)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}