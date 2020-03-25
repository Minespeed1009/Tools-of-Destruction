using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;


namespace ToolsOfDestruction.NPCs.Bosses.BossMinions
{
	public class ReaverAtk4Minion : ModNPC
	{
		private Player player;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaver Minion");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 64;
			npc.lifeMax = 69420; //nice
			npc.immortal = true;
			npc.dontTakeDamage = true;
			npc.aiStyle = -1;
			npc.damage = 40;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;;
		}

		int startupTimer = 60;
		int dashDelay = 30;
		int dashCount = 0;

		private void Target()
		{
			player = Main.player[npc.target];
		}

		public override void AI()
		{
			Target();

			float moveToX = player.position.X + (float)player.width * 0.5f - npc.Center.X;
			float moveToY = player.position.Y + (float)player.height * 0.5f - npc.Center.Y;
			float distance = (float)System.Math.Sqrt((double)(moveToX * moveToX + moveToY * moveToY));

			Lighting.AddLight(npc.Center, 0.3f, 0.4f, 0.2f);

			npc.rotation += npc.velocity.X / 25;

			npc.alpha -= 255;

			startupTimer--;

			if(startupTimer <= 0)
			{
				npc.aiStyle = 2;

				dashDelay--;
				if(dashDelay <= 0)
				{
					if(dashCount >= 3)
					{
						npc.life = -1;
					}
					else
					{
						dashDelay = 30;
						npc.velocity.X = moveToX / distance * 4;
						npc.velocity.Y = moveToY / distance * 4;
						npc.velocity *= 5;
						Main.PlaySound(36, (int)npc.position.X, (int)npc.position.Y, -1, 1f, 0);
						dashCount++;
					}
				}
			}
			else
			{
				npc.velocity *= 0.98f;
			}
		}
	}
}
