﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;
using RealmOne.Common.Systems;
using Terraria.Audio;
using RealmOne.Items.Placeables;

namespace RealmOne.Tiles.Blocks
{
    internal class TatteredWoodTile : ModTile
    {

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlendAll[this.Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;


            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Tattered Wood");
            AddMapEntry(new Color(100, 120, 70), name);

            DustType = DustID.SpookyWood;
        //    ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ModContent.ItemType<Items.Placeables.TatteredWood>();

            //HitSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/OldGoldTink");

            HitSound = rorAudio.BrokenBarrel;
            MineResist = 1f;
            MinPick = 30;
        }

        public override bool CanExplode(int i, int j)
        {
            return true;
        }
    }

}
