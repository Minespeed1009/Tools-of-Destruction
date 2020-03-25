using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class SausageCannon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Literally a sausage cannon." + $"\n[i:3456][c/1f8508: Developer Item ][i:3456]");
		}

		public override void SetDefaults() 
		{
			item.damage = 500;
			item.melee = false;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(999, 0, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 60;
			item.reuseDelay = 3; 
			item.useAnimation = 60;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item63;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("Sausage");
			item.shootSpeed = 20f;
		}
	}
}