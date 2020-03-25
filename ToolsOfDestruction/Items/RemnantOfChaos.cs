using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class RemnantOfChaos : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Remnant of Chaos");
			Tooltip.SetDefault("'All that is left of a truly chaotic past'");
		}

		public override void SetDefaults() 
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.maxStack = 999;
			item.rare = 7;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useTurn = false;
			item.autoReuse = false;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 50);
			recipe.AddIngredient(ItemID.WaterCandle);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}