using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles
{
	public class Sausage2 : ModProjectile
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
	}
}
