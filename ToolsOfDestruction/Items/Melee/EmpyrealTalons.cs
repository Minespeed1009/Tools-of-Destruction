using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Melee
{
	public class EmpyrealTalons : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empyreal Talons");

			Tooltip.SetDefault("'Scratch your foes with the fury of a star.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 250;
			item.melee = true;
			item.width = 16;
			item.height = 16;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.maxStack = 1;
			item.useStyle = 1;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useTurn = true;
			item.rare = 7;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.crit = 4;
			item.knockBack = 2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 200);
			recipe.AddIngredient(ItemID.FetidBaghnakhs);
			recipe.AddIngredient(ItemID.FragmentSolar, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}