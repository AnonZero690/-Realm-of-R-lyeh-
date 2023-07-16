﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Vanities
{
    [AutoloadEquip(EquipType.Head)]

    public class SquirmoMask : ModItem
    {
        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Squirmo Mask");
            Tooltip.SetDefault("Sludgy Stuff!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Blue; // The rarity of the item
            Item.vanity = true;

        }



        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        /*	public override bool IsArmorSet(Item head, Item body, Item legs)
            {
                return body.type == ModContent.ItemType<BrassBody>() && legs.type == ModContent.ItemType<BrassLegs>();
            }*/


    }
}
