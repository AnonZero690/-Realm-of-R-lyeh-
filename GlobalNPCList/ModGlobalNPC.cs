using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Items;
using Terraria.GameContent.ItemDropRules;
using static Terraria.GameContent.ItemDropRules.Conditions;
using RealmOne.Items.Placeables;
using System;
using RealmOne.Items.Accessories;
using Terraria.Localization;
using RealmOne.Bosses;
using RealmOne.Items.Opens;
using RealmOne.Vanities;
using System.Runtime.CompilerServices;
using RealmOne.Items.Tools.Pick;
using RealmOne.Items.Weapons.PreHM.Throwing;
using RealmOne.NPCs.Enemies.MiniBoss;
using RealmOne.Items.Misc.EnemyDrops;

namespace RealmOne.GlobalNPCList
{
    public class ModGlobalNPCList : GlobalNPC
	{
             
        // ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
        // Here we go through all of them, and how they can be used.
        // There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.
        public override void OnKill(NPC npc)
        {

            if (npc.type == ModContent.NPCType<PossessedPiggy>())
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The unusual and persistent piggy bank has been shattered!"), 71, 229, 231);

                }
            }
            if (npc.type == ModContent.NPCType<SquirmoHead>())
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The soil has been adhered, the ground has been enchanted!"), 71, 229, 231);

                }
            }
            if (npc.type == ModContent.NPCType<SquirmoHead>())
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The soil has been adhered, the ground has been enchanted!"), 71, 229, 231);

                }
            }
            if (npc.type == NPCID.KingSlime)
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The oversized glob of bacteria has been vanquished, but for what reason?"), 71, 229, 231);

                }
            }
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (Main.netMode != 2)
				{
					Main.NewText(Language.GetTextValue("The seer of the land has been slayed, but you're still being watched."), 178, 30, 250);

				}
			}
           
            if (npc.type == NPCID.BrainofCthulhu)
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The hypnotic brain of amalgamated knowledge has been slain, you feel your mind calming down."), 250, 20, 80);

                }
            }

            if (npc.type == NPCID.QueenBee)
            {
                if (Main.netMode != 2)
                {
                    Main.NewText(Language.GetTextValue("The grand protector of the hives has been killed, making insects favour you in positive or negatives ways"), 235, 221, 54);

                }
            }
        }
        public override void SpawnNPC(int npc, int tileX, int tileY)
        {
            base.SpawnNPC(npc, tileX, tileY);
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Demon)
			{
				
			    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2)); // 4 and 1 is the chance, so 1 out of 4 chance of dropping it. And two is the amount you will probably get
			}
			if (npc.type == NPCID.Hellbat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.LavaSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.FireImp)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.BoneSerpentHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}
			if (npc.type == NPCID.VoodooDemon)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}

			if (npc.type == NPCID.Demon)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}


			//Goblin Army
			if (npc.type == NPCID.GoblinArcher)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4	, 1, 3));

			}
			if (npc.type == NPCID.GoblinPeon)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinScout)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinThief)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinWarrior)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinSorcerer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinSummoner)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 5));
			}

			if (npc.type == NPCID.ServantofCthulhu)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshyCornea>(), 3, 1, 2));
			}

			if (npc.type == NPCID.EyeofCthulhu)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyePick>(), 10, 1, 1));

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshyCornea>(), 1, 1, 10));
			}


			if (npc.type == NPCID.WallofFlesh)
			{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Crimcore>(), 2, 1, 12));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 2, 1, 12));
			}

			if (npc.type == NPCID.KingSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoyalRawhide>(), 2, 1, 1));
			}
			if (npc.type == NPCID.SkeletronHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DungeonPendant>(), 2, 1, 1));
			}

			if (npc.type == NPCID.Vampire)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<vampdag>(), 4, 1, 30)); //4 out of 1 
			}

			if (npc.type == NPCID.VampireBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<vampdag>(), 4, 1, 30)); //4 out of 1 
			}

          
        }
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<TundraThrowingKnife>();

               
            }

            if (shop.NpcType == NPCID.GoblinTinkerer)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<GizmoScrap>();


            }

            if (shop.NpcType == NPCID.WitchDoctor)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add(ItemID.Worm);
                shop.Add(ItemID.Grubby);
                shop.Add(ItemID.Buggy);
                shop.Add(ItemID.Snail);


            }


            if (shop.NpcType == NPCID.Clothier)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<SkullMask>();
                shop.Add(ItemID.Silk);
                shop.Add(ItemID.Bone);
               


            }
            if (shop.NpcType == NPCID.Merchant)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<IllicitStash>(Condition.TimeNight);


            }
        }
      

    }
	
}
