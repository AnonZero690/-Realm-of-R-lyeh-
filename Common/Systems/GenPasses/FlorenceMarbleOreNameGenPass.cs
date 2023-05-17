﻿using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.ID;
using RealmOne.Tiles.Blocks;

namespace RealmOne.Common.Systems.GenPasses
{
    internal class FlorenceMarbleOreNameGenPass : GenPass
    {
        public FlorenceMarbleOreNameGenPass(string name, float loadWeight) : base(name, loadWeight)
        { 
        }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Revolutionising the ancient stone";

            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                int y = WorldGen.genRand.Next((int)GenVars.worldSurface, Main.maxTilesY);

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
                // Feel free to experiment with strength and step to see the shape they generate.

                
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<FlorenceMarbleTile>());
                
            }
        }
    }
    
}


