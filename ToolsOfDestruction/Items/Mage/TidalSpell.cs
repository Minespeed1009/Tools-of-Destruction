using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Mage
{
	public class TidalSpell : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tidal Spell");

			Tooltip.SetDefault("'A spell forged by the materials of the depths of the ocean.'\nPenetrates through 5 mobs.");
		}

		public override void SetDefaults() 
		{
			item.damage = 40;
			item.magic = true;
			item.width = 32;
			item.height = 32;
            item.mana = 10;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useTurn = true;
			item.rare = 5;
			item.autoReuse = true;
			item.UseSound = SoundID.Item8;
			item.crit = 25;
			item.knockBack = 2f;
			item.shoot = mod.ProjectileType("WaterArrow"); 
			item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 50);
			recipe.AddIngredient(ItemID.Seashell, 5);
            recipe.AddIngredient(ItemID.Starfish, 5);
            recipe.AddIngredient(ItemID.SharkFin, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}