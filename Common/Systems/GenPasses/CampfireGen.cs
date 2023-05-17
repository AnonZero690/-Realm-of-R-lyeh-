using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.ID;
using RealmOne.Tiles.Blocks;
using System;

namespace RealmOne.Common.Systems.GenPasses
{
    internal class CampfireGen : GenPass
    {
        public CampfireGen(string name, float loadWeight) : base(name, loadWeight)
        {
        }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int spawnX = Main.spawnTileX;
            int spawnY = Main.spawnTileY;

            progress.Message = "Campfire";

            WorldGen.PlaceTile(spawnX, spawnY, TileID.Campfire);

            // Ensure there's a flat surface underneath the campfire
            for (int i = spawnX - 1; i <= spawnX + 1; i++)
            {
                int j = spawnY + 1;
                while (j < Main.maxTilesY && !Main.tileSolid[Main.tile[i, j].TileType])
                {
                    WorldGen.TileRunner(i, j, 3, 1, TileID.Dirt);
                    j++;
                }
            }   
        }
    }

}


