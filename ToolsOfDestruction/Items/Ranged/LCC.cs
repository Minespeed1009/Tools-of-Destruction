using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
namespace ToolsOfDestruction.Items.Ranged
{
public class LCC : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lihzahrd Crystal Crasher");
			Tooltip.SetDefault("Fires an extra explosive crystal");
		}

		public override void SetDefaults() 
		{
			item.damage = 47;
			item.ranged = true;
			item.width = 60;
			item.height = 60;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 25;
			item.useAnimation = 25;
			item.rare = 5;
			item.autoReuse = true;
			item.knockBack = 10f;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet; 
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 43f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Main.PlaySound(SoundID.Item36, player.position);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("LCCProj"), damage, 0f, player.whoAmI);

			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, 0f, player.whoAmI);
			}

			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, -1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 50);
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(ItemID.OnyxBlaster);
			recipe.AddIngredient(ItemID.BeetleHusk, 18);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}