using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Summon
{
	public class StardustMortarStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stardust Mortar Staff");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.damage = 100;
			item.mana = 20;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.maxStack = 1;
			item.noMelee = true;
			item.rare = 4;
			item.useStyle = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.shoot = mod.ProjectileType("StardustMortarProj");
			item.UseSound = SoundID.Item8;
			item.summon = true;
			item.sentry = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 200);
            recipe.AddIngredient(ItemID.FragmentStardust, 25);
			recipe.AddIngredient(ItemID.StaffoftheFrostHydra);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = SPos;
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile proj = Main.projectile[i];
				if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}

			return true;
		}
	}
}