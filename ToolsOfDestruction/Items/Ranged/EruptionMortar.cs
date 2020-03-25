using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class EruptionMortar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Thou hast been smitten by bombus'\nShoots a bomb that explodes on contact into more bombs.");
		}

		public override void SetDefaults() 
		{
			item.damage = 75;
			item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 12;
			item.useAnimation = 12;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item10;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("EruptionBomb1");
			item.shootSpeed = 10f;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 100);
			recipe.AddIngredient(mod.ItemType("AnarchyBomber"));
			recipe.AddIngredient(mod.ItemType("StarRailer"));
			recipe.AddIngredient(mod.ItemType("ChaoticBoltCannon"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}