﻿using RealmOne.NPCs.Critters.Farm;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.ItemCritter
{
    public class HoneyHareItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Honey Hare");

        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 99;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(gold: 1, silver: 75);
        }

        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<HoneyHare>());
            return true;
        }
    }
}
