﻿using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using RealmOne.Items.Placeables;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using RealmOne.Tiles.Blocks;

namespace RealmOne.Items.Placeables
{
    internal class TatteredWood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tattered Wood");
            // Tooltip.SetDefault("Guaranteed Splinters");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(silver: 20, copper: 50);
            Item.rare = 2;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;


            Item.createTile = ModContent.TileType<Tiles.Blocks.TatteredWoodTile>();
        }
    }
}