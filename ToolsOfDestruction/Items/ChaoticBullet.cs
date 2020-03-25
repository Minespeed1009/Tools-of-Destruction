using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class ChaoticBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaotic Bullet");
		}

		public override void SetDefaults() 
		{
			item.damage = 4;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f;
			item.value = Item.buyPrice(copper : 10);
			item.rare = 1;
			item.shoot = mod.ProjectileType("ChaoticBulletProjectile");
			item.shootSpeed = 5f;
			item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}