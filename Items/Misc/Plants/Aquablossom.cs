﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.Misc.Plants
{
    public class Aquablossom : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquablossom");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;

        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 1, 10);
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            maxFallSpeed = 0.1f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.AliceBlue;

        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            else
                frame = texture.Frame();

            Vector2 frameOrigin = frame.Size() / 2f;
            var offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
                time = 2f - time;

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(30, 180, 230, 70), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
    }
}
