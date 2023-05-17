using System;
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

    public class AquaBlossomBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Aqua Blossom Cuirass");
            /* Tooltip.SetDefault("6% increases magic damage"
                +"\n20+ Max Mana"
                +"\n'Wet armour? No thanks.'"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void SetDefaults()
        { 
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 3; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.06f;
            player.statManaMax2 += 20;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect


        // UpdateArmorSet allows you to give set bonuses to the armor.



    }
}
