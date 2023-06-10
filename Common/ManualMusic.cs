﻿using Terraria.ModLoader;

namespace RealmOne.Common
{
    
    public sealed class ManualMusic : ILoadable
    {
        public void Load(Mod mod)
        {
            

            MusicLoader.AddMusic(mod, "Assets/Music/SquirmoDrip");
            MusicLoader.AddMusic(mod, "Assets/Music/Rlyeh");
            MusicLoader.AddMusic(mod, "Assets/Music/PiggyPatrol");


        }

        public void Unload() 
        {
      
        }
    }
}

