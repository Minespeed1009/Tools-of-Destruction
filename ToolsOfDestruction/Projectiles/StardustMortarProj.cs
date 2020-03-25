using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles
{
	public class StardustMortarProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Mortar");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.ignoreWater = false;
			projectile.sentry = true;
			projectile.netImportant = true;
		}

		public override void AI()
		{
			projectile.velocity.X = 0f;
            projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }

			projectile.rotation = 0f;

			for (int i = 0; i < 200; i++)
			{
				NPC target = Main.npc[i];

				float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
				float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

				float idkX = 0.01f;
				float idkY = -10f;

				if (distance < 1040f && !target.friendly && target.active)
				{
					if (projectile.ai[0] > 30f)
					{
						if (target.position.Y >= projectile.position.Y - 50f)
						{
							idkY = -10f;
							idkX = 0.015f;
						} else if (target.position.Y < projectile.position.Y - 50f)
						{
							idkY = -20f;
							idkX = 0.0075f;
						}

						distance = 1.6f / distance;

						float movementCompensateX = target.position.X + target.velocity.X + (float)target.width * 0.5f - projectile.Center.X;

						int damage = 100;

						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, movementCompensateX * idkX, idkY, mod.ProjectileType("StardustMortarShot"), damage, 0, Main.myPlayer, 0f, 0f);
						Main.PlaySound(SoundID.Item62, projectile.position);
						projectile.ai[0] = 0f;
					}
				}
			}
			projectile.ai[0] += 1f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
	}
}
