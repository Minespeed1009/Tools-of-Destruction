using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles
{
	public class ReaverLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 8;
			projectile.timeLeft = 240;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
	}
}
