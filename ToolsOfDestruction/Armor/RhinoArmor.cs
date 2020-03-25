using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Armor
{
    [AutoloadEquip(EquipType.Body)]
	public class RhinoArmor : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhino Chestplate");
            Tooltip.SetDefault("Stab your enemies 37 times in the chest with your head");
        }
		public override void SetDefaults() 
		{
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 4;
            item.defense = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 50);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.Leather, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}