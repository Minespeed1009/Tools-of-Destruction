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
	public class RhinoHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhino Helmet");
            Tooltip.SetDefault("Stab your enemies 37 times in the chest with your head");
        }
		public override void SetDefaults() 
		{
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 4;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("RhinoArmor") && legs.type == mod.ItemType("RhinoLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants the player more melee attack damage and a dash";
            player.dash = 2;
            player.meleeDamage *= 1.1f;
            player.meleeSpeed *= 1.1f; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 50);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}