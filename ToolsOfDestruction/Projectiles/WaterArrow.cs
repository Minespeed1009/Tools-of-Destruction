using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class WaterArrow : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Water Arrow");
		}

		public override void SetDefaults() 
		{
			projectile.width = 32;
			projectile.height = 32;

			// 0 = Bullet
			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 1;

			projectile.friendly = true;

			projectile.penetrate = 5;

			projectile.ranged = true;

			projectile.arrow = false;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			float speedX = Main.rand.NextFloat(-0.5f, 0.5f);
			float speedY = Main.rand.NextFloat(-0.5f, 0.5f);
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 33, speedX, speedY, 100, default(Color), 1f);
		}
	}
}