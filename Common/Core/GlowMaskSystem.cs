using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Common.Core
{
    public class GlowMaskSystem
    {
        public static void DrawItemGlowMask(Texture2D texture, PlayerDrawSet info)
        {
            Item item = info.drawPlayer.HeldItem;
            if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == ItemUseStyleID.None) && (item.holdStyle <= 0 || info.drawPlayer.pulley)) || info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet))
                return;

            Vector2 offset = Vector2.Zero;
            Vector2 origin = Vector2.Zero;
            float rotOffset = 0;

            if (item.useStyle == ItemUseStyleID.Shoot)
            {
                if (Item.staff[item.type])
                {
                    rotOffset = 0.785f * info.drawPlayer.direction;
                    if (info.drawPlayer.gravDir == -1f)
                        rotOffset -= 1.57f * info.drawPlayer.direction;

                    origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);

                    int oldOriginX = -(int)origin.X;
                    ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
                    offset = new Vector2(origin.X + oldOriginX, 0);
                }
                else
                {
                    offset = new Vector2(10, texture.Height / 2);
                    ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);
                    origin = new Vector2(-offset.X, texture.Height / 2);
                    if (info.drawPlayer.direction == -1)
                        origin.X = texture.Width + offset.X;

                    offset = new Vector2(texture.Width / 2, offset.Y);
                }
            }
            else
            {
                origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
            }

            info.DrawDataCache.Add(new DrawData(
                texture,
                info.ItemLocation - Main.screenPosition + offset,
                texture.Bounds,
                Color.White * ((255f - item.alpha) / 255f),
                info.drawPlayer.itemRotation + rotOffset,
                origin,
                item.scale,
                info.playerEffect,
                0
            ));
        }
    }
}