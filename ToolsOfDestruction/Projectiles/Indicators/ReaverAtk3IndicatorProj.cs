using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles.Indicators
{
	public class ReaverAtk3IndicatorProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 240;
			projectile.penetrate = 1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 119;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0, 0, 0, default(Color), 1.2f);
			Main.dust[num1].velocity *= 0f;
			Main.dust[num1].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 120);
		}
	}
}
