using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Armor
{
    [AutoloadEquip(EquipType.Head)]
	public class ChaoticSights : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaotic Sights");
            Tooltip.SetDefault("'Forged from the remains of the reaver itself.'");
        }
		public override void SetDefaults() 
		{
            item.width = 22;
            item.height = 18;
            item.value = 250000;
            item.rare = 4;
            item.defense = 19;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ChaoticArmor") && legs.type == mod.ItemType("ChaoticLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased ranged damage\nIncreased ranged critical strike chance";
            player.rangedDamage *= 1.2f;
            player.rangedCrit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 50);
            recipe.AddIngredient(mod.ItemType("ReaverParts"), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}