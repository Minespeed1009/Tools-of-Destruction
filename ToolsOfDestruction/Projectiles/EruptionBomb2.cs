using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class EruptionBomb2 : ModProjectile
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

			projectile.timeLeft = 120;

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
		}
	}
}