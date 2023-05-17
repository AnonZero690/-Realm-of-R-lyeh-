using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLogic.Utilities;
using Microsoft.Xna.Framework.Audio;
using ReLogic.Graphics;
using Terraria;

using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RealmOne.Common.Core
{
    public static partial class Helper
    {
        public static Color IndicatorColor => Color.White * (float)(0.2f + 0.8f * (1 + 2f));

    }
}
