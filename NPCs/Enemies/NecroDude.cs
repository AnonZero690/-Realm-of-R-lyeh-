﻿using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using RealmOne.Items.Misc;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using RealmOne.Items.Weapons.Ranged;
using RealmOne.Items;
using RealmOne.Common;
using Terraria.Audio;
using RealmOne.Projectiles;
using RealmOne.Items.Tools.Hooks;
using RealmOne.Items.Weapons.PreHM.Forest;
using RealmOne.Items.Placeables;
using RealmOne.Items.Misc.EnemyDrops;

namespace RealmOne.NPCs.Enemies
{
    public class NecroDude : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Necro Envoyholder");
            Main.npcFrameCount[NPC.type] = 6;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };

            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                CustomTexturePath = "RealmOne/Assets/Textures/Classified", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
                
                Position = new Vector2(40f, 28f),
                PortraitPositionXOverride = 0f,
                PortraitPositionYOverride = 12f,
                PortraitScale = 1.5f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }

        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 42;
            NPC.damage = 24;
            NPC.defense = 1;
            NPC.lifeMax = 90;
            NPC.value = 90f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit36;
            NPC.DeathSound = SoundID.NPCDeath50;
            NPC.netAlways = true;
            NPC.netUpdate = true;
            NPC.npcSlots = 0;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Overworld.Chance * 0.14f;
        }


        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.14f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A y'tarp ph'nglui n'ghftnah cloak ah'f'nah be'wa ot orr'ee.  Ah'n'gha nilgh'ri oi'uytalesi ph'lyutio yta."),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TatteredBarrelItem>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Parchment>(), 2, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EidolicInk>(), 4, 1, 1));

        }
        
        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int i = 0; i < 20; i++)
            {

                Vector2 speed = Main.rand.NextVector2Square(1f, 1f);

                Dust d = Dust.NewDustPerfect(NPC.position, DustID.Obsidian, speed * 5, Scale: 1.5f); ;
                d.noGravity = true;

            }


            if (Main.netMode != NetmodeID.Server)
            {
                if (NPC.life <= 0)
                {
                    // These gores work by simply existing as a texture inside any folder which path contains "Gores/"

                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NecroDudeGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NecroDudeGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NecroDudeGore3").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NecroDudeStick").Type, 1f);

                }
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            int buffType = BuffID.Darkness;
            // Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

            int timeToAdd = 5 * 60; //This makes it 5 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);

        }
        public override void AI()
        {
            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);
            NPC.spriteDirection = NPC.direction;


            Vector2 center = NPC.Center;
            for (int j = 0; j < 70; j++)
            {
                int dust1 = Dust.NewDust(center, 0, 0, DustID.ShadowbeamStaff, 0f, 0f, 100, default, 0.6f);
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].velocity = Vector2.Zero;
                Main.dust[dust1].noLight = false;


            }
        }
    }
}
