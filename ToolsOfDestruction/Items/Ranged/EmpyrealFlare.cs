using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Ranged
{
	public class EmpyrealFlare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empyreal Flare");
			Tooltip.SetDefault("'Embrace the power of nuclear fusion'" + $"\n[i:3456][c/1f8508: Developer Item ][i:3456]");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 54;
			item.height = 26;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item72;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("EmpyrealFlareProj");
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-9, -1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.ShadowbeamStaff);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
