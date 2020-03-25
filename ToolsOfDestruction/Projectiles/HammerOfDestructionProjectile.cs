using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Projectiles
{
	public class HammerOfDestructionProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thrown Mjolnir");
		}

		public override void SetDefaults() 
		{
			projectile.width = 32;
			projectile.height = 32;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 3;

			projectile.friendly = true;

			projectile.penetrate = 250;

			projectile.melee = true;

			projectile.damage = 25;
			projectile.knockBack = 0.5f;

			projectile.arrow = false;
		}
	}
}