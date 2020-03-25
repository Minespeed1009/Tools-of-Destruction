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
	public class ChaoticArmor : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaotic Chestplate");
            Tooltip.SetDefault("'Forged from the remains of the reaver itself.'");
        }
		public override void SetDefaults() 
		{
            item.width = 30;
            item.height = 20;
            item.value = 250000;
            item.rare = 6;
            item.defense = 26;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 50);
            recipe.AddIngredient(mod.ItemType("ReaverParts"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}