using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Throwing
{
	public class ChaoticKnifeOfBoom : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Boom Boom, Zoom Zoom.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.thrown = true;
			item.width = 16;
			item.height = 32;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 999;
			item.useStyle = 1;
			item.useTime = 15;
			item.useAnimation = 15;
			item.consumable = true;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item19;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("ChaoticKnifeOfBoomProjectile");
			item.shootSpeed = 10f;
			item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 200);
			recipe.AddIngredient(ItemID.ThrowingKnife, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}