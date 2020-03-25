using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class StardustMortarShot : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mortar Shot");
		}

		public override void SetDefaults() 
		{
			projectile.width = 24;
			projectile.height = 24;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 0;

			projectile.friendly = true;

			projectile.penetrate = 1;

			projectile.damage = 100;
			projectile.knockBack = 0.5f;

			projectile.arrow = false;
		}

		public override void AI()
		{
			projectile.rotation += 0.5f;

			projectile.velocity.Y += 0.25f;

			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, 0, 0, 0, default(Color), 1.2f);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
            {
                int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, 0, 0, 0, default(Color), 1.2f);
            }

			Main.PlaySound(SoundID.Item14, projectile.position);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("StardustExplosion"), projectile.damage, 0f, 0);
		}
	}
}