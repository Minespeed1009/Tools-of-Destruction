using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles
{
	public class Sausage : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 4;
			projectile.penetrate = -1;
			projectile.friendly = true; 
			projectile.timeLeft = 180;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 12; i++)
			{
				Vector2 shotAngle = new Vector2(0f, 8f).RotatedBy(MathHelper.ToDegrees(30 * i));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, shotAngle.X, shotAngle.Y, mod.ProjectileType("Sausage1"), projectile.damage, 0f, 0);
			}
		}
	}
}
