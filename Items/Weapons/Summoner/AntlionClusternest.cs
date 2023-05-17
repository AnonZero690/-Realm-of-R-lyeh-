using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using System;
using RealmOne.Common.Systems;
using Microsoft.Xna.Framework;
using RealmOne.Common.DamageClasses;
using System.Collections.Generic;
using RealmOne.Projectiles;
using RealmOne.Projectiles.Summoner;

namespace RealmOne.Items.Weapons.Summoner
{
    public class AntlionClusternest : ModItem
    {


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Antlion Clusternest"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            /* Tooltip.SetDefault("Throws a nest full of aggressive antlion larva"
                + "\nPlease do not let this thing in your house."); */


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {

            Item.damage = 12;
            Item.DamageType = DamageClass.Summon;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.useStyle = 1;
            Item.knockBack = 1f;
            Item.value = Item.buyPrice(silver: 50, copper: 80);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MiniNest>();
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            Item.scale = 0.8f;

            Item.noUseGraphic = true;

        }




        
       
    }
}