using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class ChaoticKnifeOfBoomProjectile : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaotic Knife Of Boom");
		}

		public override void SetDefaults() 
		{
			projectile.width = 12;
			projectile.height = 24;

			projectile.friendly = true;

			projectile.penetrate = 3;

			projectile.thrown = true;

			projectile.damage = 50;
			projectile.knockBack = 0.5f;
			projectile.tileCollide = true;

			projectile.arrow = false;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.velocity.Y += 0.2f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
			projectile.velocity = target.velocity;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity *= 0f;
			projectile.rotation = 3.14f;
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("ChaoticExplosion"), 35, 0, Main.myPlayer, 0f, 0f);
			Main.PlaySound(SoundID.Item89, projectile.position);
		}
	}
}