using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ToolsOfDestruction.Items
{
    public class ChaoticPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Massively increased spawn rates" + $"\n[c/aa4444:Just don't.]");
            
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 28;
            item.value = 250000;                
            item.rare = 5;
            item.buffType = mod.BuffType("ChaoticPotionBuff");
            item.buffTime = 300;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 100);
            recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 100);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }*/
    }
}