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
using RealmOne.Common.DamageClasses;

namespace RealmOne.Armor
{
    [AutoloadEquip(EquipType.Head)]

    public class AquaBlossomHead : ModItem
    {
        public override void SetStaticDefaults()
        {
           
            // DisplayName.SetDefault("Aqua Blossom Lilyhat");
            // Tooltip.SetDefault("5% increased magic crit chance");

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
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 2; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Magic) += 0.5f;
      //      player.GetDamage(ModContent.GetInstance<DemolitionClass>()) += 0.5f;
            
            
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AquaBlossomBody>() && legs.type == ModContent.ItemType<AquaBlossomLegs>();
        }

        int Watertimer = 0;

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Shine effect. Even larger while underwater"+"\nGills effect and flipper underwater" +"\n2+ mana regen."; // This is the setbonus tooltip
            player.gills = true;
            Lighting.AddLight(player.position, 0.08f, 0.4f, 0.8f) ;
            Lighting.Brightness(2, 2);
           Watertimer++;

            if (Watertimer == 7)
            {
                int d = Dust.NewDust(player.position, player.width, player.height, DustID.Water_Hallowed);
                Main.dust[d].scale = 1.5f;
                Main.dust[d].velocity *= 0.6f;
                Main.dust[d].noLight = false;
                
                
                Watertimer = 0;
            }
            player.manaRegen += 2;
        }



       
    }
}
