using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class CyclonicGuardian : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Thou hast been smitten with bombs.");
		}

		public override void SetDefaults() 
		{
			item.damage = 140;
			item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 20;
			item.useAnimation = 20;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item11;
			item.crit = 4;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("CyclonicTorpedo");
			item.shootSpeed = 20f;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 200);
            recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.AddIngredient(ItemID.SnowmanCannon);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}