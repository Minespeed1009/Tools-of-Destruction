using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;


namespace ToolsOfDestruction.NPCs.Bosses.BossMinions
{
	public class ReaverClone : ModNPC
	{
		private Player player;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaver Clone");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.lifeMax = 4000;
			npc.aiStyle = -1;
			npc.damage = 40;
			npc.knockBackResist = 0f;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true; ;
		}

		int startupTimer = 60;
		int dashDelay = 30;
		int dashCount = 0;
		int phase = 0;
		int p1Timer = 40;
		bool p1HasShot = false;

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

			npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f; ;

			npc.alpha -= 255;

			startupTimer--;

			if (startupTimer <= 0)
			{
				npc.aiStyle = 2;

				dashDelay--;
				if (phase == 0)
				{
					if (dashDelay <= 0 && phase == 0)
					{
						if (dashCount >= 3)
						{
							phase = 1;
							dashCount = 0;
						}
						else
						{
							dashDelay = Main.rand.Next(20, 30);
							npc.velocity.X = moveToX / distance * (2f + Main.rand.NextFloat());
							npc.velocity.Y = moveToY / distance * (2f + Main.rand.NextFloat());
							npc.velocity *= 5;
							dashCount++;
						}
					}
				}
				else if (phase == 1)
				{
					npc.velocity *= 0.99f;
					if (!p1HasShot)
					{
						if (Main.netMode != 1)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, moveToX / distance * 8, moveToY / distance * 8, mod.ProjectileType("ReaverBolt"), 40, 0f, Main.myPlayer);
						}
						Main.PlaySound(SoundID.Item124, npc.position);
						p1HasShot = true;
					}
					p1Timer--;
					if (p1Timer <= 0)
					{
						phase = 0;
						p1HasShot = false;
						p1Timer = 40;
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
