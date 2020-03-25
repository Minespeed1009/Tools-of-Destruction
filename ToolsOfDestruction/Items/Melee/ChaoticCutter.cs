using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Melee
{
	public class ChaoticCutter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaotic Cutter");
		}

		public override void SetDefaults() 
		{
			item.damage = 78;
			item.melee = true;
			item.width = 16;
			item.height = 16;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.maxStack = 1;
			item.useStyle = 1;
			item.useTime = 12;
			item.useAnimation = 12;
			item.rare = 7;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.knockBack = 2f;
			item.shoot = mod.ProjectileType("ChaosMeteorFriendly");
			item.shootSpeed = 10f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ChaoticCutterProj"), damage, knockBack, player.whoAmI, 0f);

			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			for (int i = 0; i < 3; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f);
			}
			return false;
		}
	}
}