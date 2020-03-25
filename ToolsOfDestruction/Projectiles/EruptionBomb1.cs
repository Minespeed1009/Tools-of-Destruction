using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class EruptionBomb1 : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eruption Bomb");
		}

		public override void SetDefaults() 
		{
			projectile.width = 12;
			projectile.height = 12;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 0;
			projectile.light = 0.7f;

			projectile.friendly = true;

			projectile.penetrate = 1;

			projectile.timeLeft = 300;

			projectile.magic = true;

			projectile.arrow = false;
		}

		public override void AI()
		{
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, 0, 0, 0, default(Color), 1.2f);
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, 0, 0, 0, default(Color), 1.2f);
            }

			Main.PlaySound(SoundID.Item14, projectile.position);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("FireExplosion"), projectile.damage, 0f, 0);
			for (int j = 0; j < 12; j++)
			{
				Vector2 shotAngle = new Vector2(0f, 8f).RotatedBy(MathHelper.ToDegrees(30 * j));
				Vector2 dustAngle = new Vector2(0f, 100f).RotatedBy(MathHelper.ToDegrees(30 * j));
				int num2 = Dust.NewDust(dustAngle, projectile.width, projectile.height, 127, 0, 0, 0, default(Color), 1.2f);
				int num3 = Dust.NewDust(dustAngle, projectile.width, projectile.height, 127, 0, 0, 0, default(Color), 1.2f);
				int num4 = Dust.NewDust(dustAngle, projectile.width, projectile.height, 127, 0, 0, 0, default(Color), 1.2f);
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, shotAngle.X, shotAngle.Y, mod.ProjectileType("EruptionBomb2"), projectile.damage / 12, 0f, 0);
			}
		}
	}
}