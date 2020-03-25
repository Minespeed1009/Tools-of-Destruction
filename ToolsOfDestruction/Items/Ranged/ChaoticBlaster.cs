using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class ChaoticBlaster : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Fires a blast of concentrated chaos.");
		}

		public override void SetDefaults() 
		{
			item.damage = 60;
			item.melee = false;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 15;
			item.reuseDelay = 20; 
			item.useAnimation = 15;
			item.rare = 6;
			item.autoReuse = true;
			item.UseSound = SoundID.Item33;
			item.crit = 25;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("ChaosBlast");
			item.shootSpeed = 16f;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
	}
}