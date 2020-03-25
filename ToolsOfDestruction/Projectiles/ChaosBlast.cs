using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Projectiles
{
	public class ChaosBlast : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaos Blast");
		}

		public override void SetDefaults() 
		{
			projectile.width = 8;
			projectile.height = 28;

			// 1 = Arrow
			// 2 = Shuriken
			// 3 = Boomerang
			projectile.aiStyle = 0;
			projectile.light = 0.7f;

			projectile.friendly = true;

			projectile.penetrate = 250;

			projectile.melee = false;

			projectile.damage = 25;
			projectile.knockBack = 0.5f;

			projectile.arrow = false;

			aiType = ProjectileID.Bullet;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) //glowmask
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
                    projectile.position.Y - Main.screenPosition.Y + projectile.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                projectile.rotation,
                texture.Size() * 0.5f,
                projectile.scale,
                SpriteEffects.None,
                0f
            );
        }
	}
}