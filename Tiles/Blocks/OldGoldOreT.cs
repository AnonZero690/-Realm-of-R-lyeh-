﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;
using RealmOne.Common.Systems;
using Terraria.Audio;


namespace RealmOne.Tiles.Blocks
{
    internal class OldGoldOreT : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 900;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;



            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Old Gold Ore");
            AddMapEntry(new Color(243, 255, 0), name);

            DustType = DustID.Gold;
        //    ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ModContent.ItemType<Items.Placeables.OldGoldOre>();

            //HitSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/OldGoldTink");

            HitSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/OldGoldTink");
            MineResist = 1.5f;
            MinPick = 60;
        }
    }
}