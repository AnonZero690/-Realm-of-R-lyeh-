﻿using RealmOne.Tiles.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.Placeables
{
    internal class FarmSoilItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Farm Soil");
            Tooltip.SetDefault("Sloppy and full of weeds");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(silver: 1, copper: 50);
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<FarmSoil>();
        }
    }
}
