﻿using RealmOne.NPCs.Critters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.ItemCritter
{
    public class AquaSwishFishItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AquaSwish Fish");

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
            Item.value = Item.sellPrice(gold: 1, silver: 80);
        }

        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<AquaSwishFish>());
            return true;
        }
    }
}
