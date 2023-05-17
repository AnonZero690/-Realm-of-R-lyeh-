﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RealmOne.Bosses;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ModLoader;

namespace RealmOne.BossBars
{
	// Shows basic boss bar code using a custom colored texture. It only does visual things, so for a more practical boss bar, see the other example (MinionBossBossBar)
	// To use this, in an NPCs SetDefaults, write:
	//  NPC.BossBar = ModContent.GetInstance<ExampleBossBar>();

	// Keep in mind that if the NPC has a boss head icon, it will automatically have the common boss health bar from vanilla. A ModBossBar is not mandatory for a boss.

	// You can make it so your NPC never shows a boss bar, such as Dungeon Guardian or Lunatic Cultist Clone:
	//  NPC.BossBar = Main.BigBossProgressBar.NeverValid;
	public class SquirmoBar : ModBossBar
	{

		private int bossHeadIndex = -1;

		public override Asset<Texture2D> GetIconTexture(ref Rectangle? iconFrame)
		{
			// Display the previously assigned head index
			if (bossHeadIndex != -1)
			{
				return TextureAssets.NpcHeadBoss[bossHeadIndex];
			}

			return null;
		}

		public override bool? ModifyInfo(ref BigProgressBarInfo info, ref float life, ref float lifeMax, ref float shield, ref float shieldMax)/* tModPorter Note: life and shield current and max values are now separate to allow for hp/shield number text draw */
		{
			// Here the game wants to know if to draw the boss bar or not. Return false whenever the conditions don't apply.
			// If there is no possibility of returning false (or null) the bar will get drawn at times when it shouldn't, so write defensive code!

			NPC npc = Main.npc[info.npcIndexToAimAt];
			if (!npc.active)
				return false;

			// We assign bossHeadIndex here because we need to use it in GetIconTexture
			bossHeadIndex = npc.GetBossHeadTextureIndex();

			lifePercent = Utils.Clamp(npc.life / (float)npc.lifeMax, 0f, 1f);

			if (npc.ModNPC is SquirmoHead body)
			{
				// We did all the calculation work on RemainingShields inside the body NPC already so we just have to fetch the value again
				shieldPercent = Utils.Clamp(body.RemainingShields, 0f, 1f);
			}

			return true;
		}
	}
}