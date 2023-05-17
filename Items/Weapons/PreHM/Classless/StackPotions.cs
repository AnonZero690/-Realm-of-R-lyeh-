﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles.Throwing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using RealmOne.Buffs;
using RealmOne.Common.DamageClasses;
using RealmOne.Projectiles.Explosive;
using Terraria.Audio;

namespace RealmOne.Items.Weapons.PreHM.Classless
{
    public class StackPotions : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Stack Of Potions"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            /* Tooltip.SetDefault("Throws a bundle of different potions"
                + "\nWhen the bundle is smashed, it has a chance of dropping a random potion on drop"
                + "\nRight Click to Drink a random potion"); */


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Generic;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = 1;
            Item.knockBack = 1f;
            Item.value = 20000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<StackPotionsProj>();
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.consumable = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {

                Item.useStyle = ItemUseStyleID.DrinkLiquid;
                Item.useTime = 35;
                Item.useAnimation = 35;


                Item.shoot = ProjectileID.None;
                Item.value = 500;
                Item.rare = 2;
                Item.consumable = true;

                Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/LightbulbShine");

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Ironskin, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Swiftness, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Regeneration, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Endurance, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.ManaRegeneration, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.MagicPower, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Spelunker, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.Shine, 240);

                if (Main.rand.NextBool(5))
                    player.AddBuff(BuffID.NightOwl, 240);

            }


            else
            {
                Item.damage = 20;
                Item.DamageType = DamageClass.Generic;
                Item.width = 24;
                Item.height = 24;
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.useStyle = 1;
                Item.knockBack = 1f;
                Item.value = 20000;
                Item.rare = 1;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = true;
                Item.maxStack = 999;
                Item.shoot = ModContent.ProjectileType<StackPotionsProj>();
                Item.shootSpeed = 12f;
                Item.noMelee = true;
                Item.noUseGraphic = true;
                Item.consumable = true;
            }
            return base.CanUseItem(player);
        }



        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.Pink.ToVector3() * 1f);
            Lighting.AddLight(Item.Right, Color.LightGreen.ToVector3() * 1f);
            Lighting.AddLight(Item.Left, Color.Yellow.ToVector3() * 1f);


            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.PinkTorch, velocity);
                dust.scale = 0.5f;
                dust.fadeIn = 0.4f;
                dust.noGravity = true;
                dust.noLight = false;
                dust.alpha = 0;


                Dust dustright = Dust.NewDustPerfect(Item.Right + direction * distance, DustID.GreenTorch, velocity);
                dustright.scale = 0.5f;
                dustright.fadeIn = 0.4f;
                dustright.noGravity = true;
                dustright.noLight = false;
                dustright.alpha = 0;

                Dust dustleft = Dust.NewDustPerfect(Item.Right + direction * distance, DustID.YellowTorch, velocity);
                dustleft.scale = 0.5f;
                dustleft.fadeIn = 0.4f;
                dustleft.noGravity = true;
                dustleft.noLight = false;
                dustleft.alpha = 0;
            }
        }

    }
}