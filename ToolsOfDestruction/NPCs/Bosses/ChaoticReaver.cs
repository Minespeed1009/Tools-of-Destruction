using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ToolsOfDestruction.NPCs.Bosses
{
    [AutoloadBossHead]
	public class ChaoticReaver : ModNPC
	{
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaotic Reaver");
            Main.npcFrameCount[npc.type] = 1;
        }

		public override void SetDefaults() 
		{
            npc.width = 128;
            npc.height = 128;
            npc.lifeMax = 60000;

            npc.boss = true;
            npc.aiStyle = 2;
            npc.damage = 65;
            npc.defense = 50;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(gold: 10);

            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit36;
            npc.DeathSound = SoundID.NPCDeath10;
            music = MusicID.Boss3;

            bossBag = mod.ItemType("ChaoticReaverBag");
		}

		int attacks = 8;
		int startTimer = 360;
		int timer1 = 0;
        int timer2 = 0;
		int atk2AfterTimer = 60;
		int atk2DashTime = 40;
		int atk3DashTime = 160;
		int atk3ShootTimer = 6;
		int atkNum = 0;
		int oldAtkNum = 0;
		int atk2DashCount = 0;
		int atk4ActiveTime = 240;
		int atk5MeteorDelay = 7;
		int atk5MeteorCount = 0;
		int atk6DashTime = 40;
		int atk6DashDelay = 30;
		int atk6DashCount = 0;
		int atk7ShootDelay = 10;
		int atk7ShootCount = 0;
		int atk8StartTime = 60;
		int atk8ShootDelay = 5;
		int atk8ShotCount = 0;

		int quoteNum = 0;

		bool hasDashedAtk1 = false;
		bool hasDashedAtk3 = false;
		bool atk2Above = false;
		bool hasSpawnedAtk4 = false;
		bool atk3StartedForSound = false;
		bool hasSpawnedClones = false;
		bool hasDashedAtk6 = false;

        private void Target()
        {
            player = Main.player[npc.target];
        }

		private void ChangeAttack()
		{
			atkNum++;
			if(atkNum == attacks + 1)
			{
				atkNum = 1;
			}
		}

        public override void AI()
        {
            Target();

			npc.TargetClosest(true);
			Player player = Main.player[npc.target];

            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 0.785f;

			float moveToX = player.position.X + (float)player.width * 0.5f - npc.Center.X;

			float moveToY = player.position.Y + (float)player.height * 0.5f - npc.Center.Y;
			float moveToAboveY = (player.position.Y - 300) + (float)player.height * 0.5f - npc.Center.Y;
			float moveToBelowY = (player.position.Y + 300) + (float)player.height * 0.5f - npc.Center.Y;

			float distance = (float)System.Math.Sqrt((double)(moveToX * moveToX + moveToY * moveToY));
			float distanceToAbove = (float)System.Math.Sqrt((double)(moveToX * moveToX + moveToAboveY * moveToAboveY));
			float distanceToBelow = (float)System.Math.Sqrt((double)(moveToX * moveToX + moveToBelowY * moveToBelowY));

			float lookToX = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
			float lookToY = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
			float lookRotation = (float)Math.Atan2((double)lookToY, (double)lookToX) + 2.355f;

			Lighting.AddLight(npc.Center, 0.6f, 0.8f, 0.4f);

			npc.alpha -= 255;

			if (distance >= 1800f)
			{
				npc.velocity.X += moveToX / distance * 0.4f;
				npc.velocity.Y += moveToY / distance * 0.4f;
			}

			if (atkNum == 0) //startup phase
			{
				if(startTimer <= 0)
				{
					atkNum = 8;
				}
				if(startTimer == 360)
				{
					Main.NewText("You think you can defeat me, mere mortal?", new Color(138, 230, 57, 200));
				}
				if (startTimer == 300)
				{
					Main.NewText("You are sorely mistaken", new Color(138, 230, 57, 200));
				}
				if(startTimer == 180)
				{
					Main.NewText("My true power will overwhelm you in seconds!", new Color(138, 230, 57, 200));
				}
				if(startTimer == 60)
				{
					Main.NewText("Face my ultimate wrath!", new Color(138, 230, 57, 200));
				}
				startTimer--;
			}
			else if(atkNum == 1) //attack 1
			{
				if(hasDashedAtk1 == false)
				{
					npc.velocity.X = moveToX / distance * 5;
					npc.velocity.Y = moveToY / distance * 5;
					npc.velocity *= 5;
					Main.PlaySound(15, npc.position, 0);
					hasDashedAtk1 = true;
				}

				timer1++;
				if (timer1 >= 120)
				{
					npc.velocity /= 3;
					timer1 = 0;
					ChangeAttack();
					hasDashedAtk1 = false;
				}

				timer2++;
				if (timer2 >= 10)
				{
					timer2 = 0;
					if (Main.netMode != 1)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ReaverProj"), 50, 0, Main.myPlayer, 0f, 0f);
					}
				}
			}
			else if (atkNum == 2) //attack 2
			{
				npc.aiStyle = -1;
				atk2DashTime--;
				atk2Above = Main.rand.NextBool();
				if(atk2DashTime <= 0 && atk2AfterTimer == 60)
				{
					if (atk2Above == false)
					{
						npc.position.Y = player.position.Y + 350;
						npc.position.X = player.Center.X - npc.width * 0.5f;
						npc.velocity.Y = -13f;
					}
					else
					{
						npc.position.Y = player.position.Y - 350;
						npc.position.X = player.Center.X - npc.width * 0.5f;
						npc.velocity.Y = 13f;
					}
					npc.velocity.X = 0f;
					atk2DashTime = 40;
					atk2DashCount += 1;
					Main.PlaySound(SoundID.Item8, npc.position);
					npc.netUpdate = true;
				}
				if (atk2DashCount >= 4)
				{
					atk2AfterTimer--;
				}
				if (atk2AfterTimer <= 0)
				{
					ChangeAttack();
					atk2DashTime = 40;
					atk2DashCount = 0;
					npc.aiStyle = 2;
					atk2AfterTimer = 60;
				}

			}
			else if(atkNum == 3) //attack 3
			{
				if (!atk3StartedForSound)
				{
					Main.PlaySound(29, npc.position, 105);
					atk3StartedForSound = true;
				}
				if(distance <= 1300f && !hasDashedAtk3)
				{
					npc.velocity.X -= moveToX / distance * 0.5f;
					npc.velocity.Y -= moveToY / distance * 0.5f;

					float maxVelocity = 12f;
					if(npc.velocity.X >= maxVelocity) // i bet you there is a better way to code this max velocity
					{
						npc.velocity.X = maxVelocity;
					}
					else if(npc.velocity.X <= -maxVelocity)
					{
						npc.velocity.X = -maxVelocity;
					}

					if (npc.velocity.Y >= maxVelocity)
					{
						npc.velocity.Y = maxVelocity;
					}
					else if (npc.velocity.Y <= -maxVelocity)
					{
						npc.velocity.Y = -maxVelocity;
					}
				}

				if(distance >= 1300f && !hasDashedAtk3)
				{
					hasDashedAtk3 = true;

					Main.PlaySound(SoundID.Item67, player.position);

					npc.velocity.X = moveToX / distance * 35;
					npc.velocity.Y = moveToY / distance * 35;
					npc.aiStyle = -1;

					if (Main.netMode != 1)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X / 2, npc.velocity.Y / 2, mod.ProjectileType("ReaverAtk3IndicatorProj"), 0, 0f, Main.myPlayer);
					}
				}
				else
				{
					atk3ShootTimer--;
					if(atk3ShootTimer <= 0 && hasDashedAtk3)
					{
						atk3ShootTimer = 6;
						for (int i = 0; i < 2; i++)
						{
							if (Main.netMode != 1)
							{
								int laser = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, moveToX / distance * 6, moveToY / distance * 6, mod.ProjectileType("ReaverAtk3Laser"), 20, 0f, Main.myPlayer);
								Vector2 atk3LaserSpread = new Vector2(Main.projectile[laser].velocity.X, Main.projectile[laser].velocity.Y).RotatedByRandom(MathHelper.ToRadians(24));
								Main.projectile[laser].velocity = atk3LaserSpread;
							}
							Main.PlaySound(SoundID.Item12, npc.position);
						}
					}
					atk3DashTime--;
					if(atk3DashTime <= 0)
					{
						ChangeAttack();
						atk3DashTime = 160;
						npc.aiStyle = 2;
						hasDashedAtk3 = false;
						atk3StartedForSound = false;
					}
					else if(atk3DashTime <= 50)
					{
						npc.velocity *= 0.98f;
					}
				}
			}
			else if(atkNum == 4) //attack 4
			{
				if (!hasSpawnedAtk4 && distance < 500f)
				{
					for (int i = 0; i < 3; i++)
					{
						Vector2 atk4MinionSpawnRot = new Vector2(10f, 0f).RotatedBy(MathHelper.ToDegrees(120 * i));
						if (Main.netMode != 1)
						{
							int Atk4Spawn = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ReaverAtk4Minion"));
							Main.npc[Atk4Spawn].velocity = atk4MinionSpawnRot;
						}
					}
					Main.PlaySound(SoundID.Item84, npc.position);
					hasSpawnedAtk4 = true;
				}
				atk4ActiveTime--;
				if(atk4ActiveTime > 0)
				{
					npc.velocity.X += moveToX / distance * 5f;
					npc.velocity.Y += moveToAboveY / distanceToAbove * 5f;

					npc.rotation = lookRotation;

					float maxVelocity = 24f;
					if (npc.velocity.X >= maxVelocity) // i bet you there is a better way to code this max velocity
					{
						npc.velocity.X = maxVelocity;
					}
					else if (npc.velocity.X <= -maxVelocity)
					{
						npc.velocity.X = -maxVelocity;
					}

					if (npc.velocity.Y >= maxVelocity)
					{
						npc.velocity.Y = maxVelocity;
					}
					else if (npc.velocity.Y <= -maxVelocity)
					{
						npc.velocity.Y = -maxVelocity;
					}
				}
				if (atk4ActiveTime <= 0)
				{
					ChangeAttack();
					atk4ActiveTime = 240;
					hasSpawnedAtk4 = false;
				}
			}
			else if(atkNum == 5) //attack 5
			{
				npc.aiStyle = -1;
				npc.velocity *= 0.99f;
				npc.defense = 160;

				npc.rotation = lookRotation;

				if (distance >= 800f)
				{
					npc.velocity.X += moveToX / distance * 0.3f;
					npc.velocity.Y += moveToY / distance * 0.3f;
				}

				atk5MeteorDelay--;
				if(atk5MeteorDelay <= 0)
				{
					Vector2 meteorSpawnRandom = new Vector2(player.position.X + (Main.rand.NextFloat() * 1800f) - 800f, player.position.Y - 600f);
					if (Main.netMode != 1)
					{
						Projectile.NewProjectile(meteorSpawnRandom.X, meteorSpawnRandom.Y, -2f, 4f, mod.ProjectileType("ReaverMeteor"), 20, 0f, Main.myPlayer);
					}
					atk5MeteorDelay = 7;
					atk5MeteorCount++;
					if(atk5MeteorCount >= 30)
					{
						ChangeAttack();
						atk5MeteorCount = 0;
						npc.aiStyle = 2;
						npc.defense = 50;
					}
				}
			}
			else if(atkNum == 6) //attack 6
			{
				npc.rotation = lookRotation;
				npc.aiStyle = -1;
				if(atk6DashDelay > 0)
				{
					atk6DashDelay--;
					npc.velocity.Y -= 0.5f;
					npc.velocity.X *= 0.95f;
				}
				else if(atk6DashTime > 0)
				{
					if(npc.position.Y > (player.position.Y - 150) && !hasDashedAtk6) //duplicate code because i'm stupid
					{
						npc.velocity.Y -= 0.5f;
						npc.velocity.X *= 0.98f;
					}
					else if (!hasDashedAtk6)
					{
						npc.velocity.X = moveToX / distance * 20;
						npc.velocity.Y = moveToY / distance * 20;
						hasDashedAtk6 = true;
					}
					atk6DashTime--;
					if(atk6DashTime <= 0)
					{
						atk6DashDelay = 30;
						atk6DashTime = 40;
						hasDashedAtk6 = false;
						npc.velocity.Y = 0f;
						atk6DashCount++;
					}
					if(atk6DashCount >= 4)
					{
						atk6DashCount = 0;
						ChangeAttack();
					}
				}
			}
			else if(atkNum == 7) // attack 7
			{
				atk7ShootDelay--;
				if(atk7ShootDelay <= 0)
				{
					for(int i = 0; i < 3; i++)
					{
						Vector2 atk7Spread = new Vector2(moveToX / distance * 5, moveToY / distance * 5).RotatedByRandom(MathHelper.ToRadians(24));
						if (Main.netMode != 1)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, atk7Spread.X, atk7Spread.Y, mod.ProjectileType("ReaverAtk3Laser"), 20, 0f, Main.myPlayer);
						}
					}
					Main.PlaySound(SoundID.Item124, npc.position);
					atk7ShootDelay = 10;
					if(atk7ShootCount >= 3)
					{
						ChangeAttack();
						atk7ShootCount = 0;
					}
					atk7ShootCount++;
				}
			}
			else if(atkNum == 8) //attack 8
			{
				npc.rotation = lookRotation;
				npc.aiStyle = -1;
				atk8StartTime--;
				if(atk8StartTime > 0)
				{
					npc.velocity *= 0.97f;
				}
				if(atk8StartTime <= 0)
				{
					atk8ShootDelay--;
					if(atk8ShootDelay <= 0)
					{
						atk8ShotCount++;
						Vector2 atk8LaserRot = new Vector2(10f, 0f).RotatedBy(MathHelper.ToRadians(10 * atk8ShotCount));
						Main.PlaySound(SoundID.Item124, npc.position);
						for (int i = 0; i < 2; i++)
						{
							if(i == 1)
							{
								atk8LaserRot *= -1;
								if (Main.netMode != 1)
								{
									Projectile.NewProjectile(npc.Center.X, npc.Center.Y, atk8LaserRot.X, atk8LaserRot.Y, mod.ProjectileType("ReaverAtk3Laser"), 20, 0f, Main.myPlayer);
								}
							}
							else
							{
								if (Main.netMode != 1)
								{
									Projectile.NewProjectile(npc.Center.X, npc.Center.Y, atk8LaserRot.X, atk8LaserRot.Y, mod.ProjectileType("ReaverAtk3Laser"), 20, 0f, Main.myPlayer);
								}
							}
						}
						atk8ShootDelay = 5;
						if(atk8ShotCount >= 72)
						{
							atk8ShotCount = 0;
							atk8StartTime = 60;
							atk8ShootDelay = 5;
							ChangeAttack();
						}
					}
				}
			}
			if(quoteNum == 0 && npc.life <= npc.lifeMax * 0.80)
			{
				Main.NewText("You've survived longer than I excpected, I'll give you that.", new Color(138, 230, 57, 200));
				quoteNum++;
			}
			else if (quoteNum == 1 && npc.life <= npc.lifeMax * 0.50)
			{
				Main.NewText("How are you still alive?", new Color(138, 230, 57, 200));
				quoteNum++;
			}
			else if (quoteNum == 2 && npc.life <= npc.lifeMax * 0.25)
			{
				Main.NewText("I may be weak, but dont get cocky yet", new Color(138, 230, 57, 200));
				quoteNum++;
			}
			else if (quoteNum == 3 && npc.life <= npc.lifeMax * 0.10)
			{
				Main.NewText("You cannot defeat ME! I am ALL POWERFUL", new Color(138, 230, 57, 200));
				quoteNum++;
			}
			else if (quoteNum == 4 && npc.life <= npc.lifeMax * 0.05)
			{
				Main.NewText("NO! I AM ABOVE THE GODS! I CANNOT DIE!", new Color(138, 230, 57, 200));
				quoteNum++;
			}

			if (npc.life <= npc.lifeMax * 0.35 && !hasSpawnedClones)
			{
				Main.NewText("This is becoming tiring. Clones, deal with this pest", new Color(138, 230, 57, 200));
				hasSpawnedClones = true;
				for(int i = 0; i < 4; i++)
				{
					if (Main.netMode != 1)
					{
						int clone = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ReaverClone"));
					}
				}
			}

			if (NPC.AnyNPCs(mod.NPCType("ReaverClone")))
			{
				npc.immortal = true;
				npc.dontTakeDamage = true;
			}
			else
			{
				npc.immortal = false;
				npc.dontTakeDamage = false;
			}
		}

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
			npc.lifeMax = 85000;
			npc.damage = 75;
			npc.defense = 60;
        }

        public override void NPCLoot()
        {
			Main.NewText("You have bested me for now, warrior. But this will not be the end...", new Color(138, 230, 57, 200));

			if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int amountEnergy = Main.rand.Next(100) + 50;
				int amountParts = Main.rand.Next(7) + 1;
				int dropItem = Main.rand.Next(3);
				if(dropItem == 0)
				{
					Item.NewItem(npc.position, mod.ItemType("ChaoticShuriken"));
				}
				else if(dropItem == 1)
				{
					Item.NewItem(npc.position, mod.ItemType("ChaosTome"));
				}
				else if(dropItem == 2)
				{
					Item.NewItem(npc.position, mod.ItemType("ChaoticBoltCannon"));
				}
				else if (dropItem == 3)
				{
					Item.NewItem(npc.position, mod.ItemType("ChaoticCutter"));
				}
				Item.NewItem(npc.position, mod.ItemType("ChaosEnergy"), amountEnergy);
				Item.NewItem(npc.position, mod.ItemType("ReaverParts"), amountParts);
            }
        }
	}
}