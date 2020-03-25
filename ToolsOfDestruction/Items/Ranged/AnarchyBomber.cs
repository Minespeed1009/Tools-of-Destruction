using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class AnarchyBomber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Thou hast been smitten with bombs.");
		}

		public override void SetDefaults() 
		{
			item.damage = 78;
			item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 12;
			item.useAnimation = 12;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item61;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("AnarchyRocket");
			item.shootSpeed = 16f;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 50);
			recipe.AddIngredient(mod.ItemType("ChaoticBlaster"));
            recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}