using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Bestiary;
using RealmOne.Items.Misc;
using RealmOne.Projectiles.Throwing;
using RealmOne.Items.Placeables;
using RealmOne.Common.Systems;
using RealmOne.Items.Weapons.PreHM.Throwing;
using RealmOne.Items.Others;

namespace RealmOne.NPCs.TownNPC
{
    [AutoloadHead]
    public class ArcheologistNPC : ModNPC
    {
        public const string ShopName = "Shop";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Archeologist.");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1500;
                
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.ShimmerTownTransform[Type] = true;
            NPCID.Sets.ShimmerTownTransform[NPC.type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.
            NPCID.Sets.AttackType[Type] = 0; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 90;   
            NPC.Happiness
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Love)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Hate);
        }


        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.aiStyle = 7;
            NPC.damage = 20;
            NPC.defense = 30;
            NPC.lifeMax = 300;
         
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.4f;
            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("An experienced and wise explorer, writing a plethora of notes of different phenomena around the land. Will give any confident and adept traveller a mission to complete his dire requests and miscellanous."),
            });
        }
        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.AnyNPCs(NPCType<BoundArcheologist>()))
                return false;

            for (int r = 0; r < 1; r++)
            {
                Player player = Main.player[r];
                if (player.active)
                    for (int j = 0; j < player.inventory.Length; j++)
                        if (player.inventory[j].type == ItemID.PlatinumCoin)
                            return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
            => new() { "Frederick", "Marvin", "Charles", "Arthur", "George", "Albert", "Densel" };

        public override string GetChat()
        {
            var chatt = new List<string>
            {
                "My hand will never get tired of writing, even with frostbite!",
                "Exploring and researching is therapeutic",
                "Embrace nature, reject violence",
                "I could take on that beast again if I had the chance!",
                "I used to smoke, but I've kept all my cigarettes in my stash",
                "I sense great determination and morality in you"
            };
            return Main.rand.Next(chatt);
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Prospector Missions";
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
                shop = ShopName; // Name of the shop tab we want to open.
            }
        }
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)


                                        .Add(new Item(ItemID.FrostburnArrow) { shopCustomPrice = Item.buyPrice(copper: 8) })
                                        .Add(new Item(ItemID.Snowball) { shopCustomPrice = Item.buyPrice(copper: 3) })
                                        .Add(new Item(ItemID.SnowballLauncher) { shopCustomPrice = Item.buyPrice(gold: 3, silver: 80) })
                                        .Add(new Item(ItemID.SnowballCannon) { shopCustomPrice = Item.buyPrice(gold: 8, silver: 30) })
                                        .Add(new Item(ItemID.Rope) { shopCustomPrice = Item.buyPrice(copper: 90) })
                                        .Add(new Item(ItemID.HunterPotion) { shopCustomPrice = Item.buyPrice(gold: 2, silver: 50) })
                                        .Add(new Item(ItemID.TrapsightPotion) { shopCustomPrice = Item.buyPrice(gold: 2, silver: 10) })
                                        .Add(new Item(ItemID.WarmthPotion) { shopCustomPrice = Item.buyPrice(gold: 2) })
                                        .Add(new Item(ItemID.TeaKettle) { shopCustomPrice = Item.buyPrice(gold: 3) })
                                        .Add(new Item(ItemID.Teacup) { shopCustomPrice = Item.buyPrice(gold: 1, silver: 50) })
                                        .Add(new Item(ItemID.CoffeeCup) { shopCustomPrice = Item.buyPrice(gold: 3, copper: 70) })
                                        .Add(new Item(ItemID.IceTorch) { shopCustomPrice = Item.buyPrice(copper: 40) })
                                        .Add(new Item(ItemID.Campfire) { shopCustomPrice = Item.buyPrice(silver: 95) })
                                        .Add(new Item(ModContent.ItemType<StoneOvenItem>()) { shopCustomPrice = Item.buyPrice(gold: 4, silver: 20) })
                                        .Add(new Item(ItemID.Extractinator) { shopCustomPrice = Item.buyPrice(gold: 3, silver: 50) })
                                        .Add(new Item(ItemID.ChristmasTree) { shopCustomPrice = Item.buyPrice(gold: 1, silver: 95) });

            if (DownedBossSystem.downedSquirmo)
            { 


                npcShop.Add(new Item(ItemType<LoreScroll1>()) { shopCustomPrice = Item.buyPrice(gold: 3, copper: 70) });

               
            }
            npcShop.Register(); // Name of this shop tab
        }

           


        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 26;
            randExtraCooldown = 26;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileType<TundraThrowingKnifeProjectile>();
            attackDelay = 2;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            randomOffset = 2f;

        }
        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemType<TundraThrowingKnife>(), 50, false, 0, false, false);
        }
    }
}
