using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Hamaxes
{
    public class ChaoticHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Forged from the leftovers of gods'\n250 axe power\n225 hammer power");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.melee = true;
            item.width = 28;
            item.height = 28;
            item.useTime = 10;
            item.useAnimation = 10;
            item.axe = 250;
            item.hammer = 225;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 200);
			recipe.AddIngredient(mod.ItemType("ReaverPart"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}