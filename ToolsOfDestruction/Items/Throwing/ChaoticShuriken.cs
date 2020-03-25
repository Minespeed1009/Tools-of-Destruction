using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Throwing
{
	public class ChaoticShuriken : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A weapon forged from the purest form of anarchy");
		}

		public override void SetDefaults() 
		{
			item.damage = 64;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 1;
			item.useStyle = 1;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item19;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("ChaoticShurikenProjectile");
			item.shootSpeed = 16f;
			item.noUseGraphic = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 4; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 0f, player.whoAmI);
			}
			return false;
		}
	}
}