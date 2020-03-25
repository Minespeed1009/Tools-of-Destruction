using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items.Ranged
{
public class StarRailer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A high-velocity railgun, forged from the remnants of three mechanical monstrosities. Shoots a burst of six bullets.");
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.melee = false;
			item.width = 60;
			item.height = 60;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.UseSound = SoundID.Item40;
			item.useTime = 3;
			item.reuseDelay = 20; 
			item.useAnimation = 18;
			item.rare = 5;
			item.autoReuse = true;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 25);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool ConsumeAmmo(Player player)
		{
			if (player.itemAnimation < player.inventory[player.selectedItem].useAnimation - 14)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}