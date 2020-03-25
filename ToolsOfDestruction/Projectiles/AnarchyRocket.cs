using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;

namespace ToolsOfDestruction.Projectiles
{
	public class AnarchyRocket : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Anarchy Rocket");
		}

		public override void SetDefaults() 
		{
			projectile.width = 24;
			projectile.height = 24;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 1;
			projectile.light = 0.7f;

			projectile.friendly = true;

			projectile.penetrate = 1;

			projectile.ranged = true;

			projectile.damage = 50;
			projectile.knockBack = 1f;

			projectile.arrow = false;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item62, projectile.position);
		}
	}
}