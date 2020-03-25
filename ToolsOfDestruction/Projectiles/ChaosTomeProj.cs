using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class ChaosTomeProj : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaos Axe");
		}

		public override void SetDefaults() 
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.thrown = true;
			projectile.damage = 25;
			projectile.knockBack = 0.5f;
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
		}

		int startupTimer = 0;
		bool hasDashed = false;

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.6f, 0.8f, 0.4f);
			projectile.alpha -= 255;

			projectile.rotation += projectile.velocity.X / 25;

			float moveToX = Main.MouseWorld.X - projectile.Center.X;
			float moveToY = Main.MouseWorld.Y - projectile.Center.Y;
			float distance = (float)System.Math.Sqrt((double)(moveToX * moveToX + moveToY * moveToY));

			startupTimer++;
			if(startupTimer >= 40 && hasDashed == false)
			{
				hasDashed = true;
				projectile.velocity.X = moveToX / distance * 20;
				projectile.velocity.Y = moveToY / distance * 20;
			}

			if(startupTimer <= 40)
			{
				projectile.velocity *= 0.97f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 2;
        }
	}
}