using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RealmOne.Tiles.Ambient
{
    public class FarmPlants : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileNoFail[Type] = true;
            Main.tileMergeDirt[Type] = true;
            TileObjectData.newTile.RandomStyleRange = 10;
            DustType = DustID.Stone;
            HitSound = SoundID.Grass;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(120, 85, 70));
            TileID.Sets.BreakableWhenPlacing[Type] = true;
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tileBelow = Framing.GetTileSafely(i, j + 1);
            if (!tileBelow.HasTile || tileBelow.IsHalfBlock || tileBelow.TopSlope)
            {
                WorldGen.KillTile(i, j);
            }

            return true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = 2;

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
    }
}