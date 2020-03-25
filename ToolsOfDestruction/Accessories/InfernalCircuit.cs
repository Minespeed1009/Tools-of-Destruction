using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Accessories
{
    public class InfernalCircuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernal Circuit");
            Tooltip.SetDefault("'A vessel of consciousness for the sentient flame'\n20% increased movement speed\n+25% damage\n+3 life regeneration\n+20 max life");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 0;
            item.rare = 5;
            item.accessory = true;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TODPlayer>().infslag = true;
            player.GetModPlayer<TODPlayer>().malcircuit = true;
            player.allDamage *= 1.25f;
            player.lifeRegen += 3;
            player.moveSpeed += 0.2f;
            player.statLifeMax2 += 20;
            player.AddBuff(BuffID.Inferno, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 100);
            recipe.AddIngredient(mod.ItemType("MalCircuit"));
            recipe.AddIngredient(mod.ItemType("InfernalSlag"));
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}