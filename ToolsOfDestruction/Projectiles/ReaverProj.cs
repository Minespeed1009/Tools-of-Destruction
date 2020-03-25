using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;

namespace ToolsOfDestruction.Projectiles
{
	public class ReaverProj : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Reaver Disc");
		}

		public override void SetDefaults() 
		{
			projectile.width = 48;
			projectile.height = 48;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 0;

			projectile.hostile = true;

			projectile.penetrate = -1;

			projectile.damage = 70;

			projectile.timeLeft = 120;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
		}
	}
}