using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Melee
{
	public class HammerOfDestruction : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mjolnir");

			Tooltip.SetDefault("'A hammer wielded by the god of thunder'");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.maxStack = 1;
			item.useStyle = 1;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useTurn = true;
			item.rare = 5;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("HammerOfDestructionProjectile"); 
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 25);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 25);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}