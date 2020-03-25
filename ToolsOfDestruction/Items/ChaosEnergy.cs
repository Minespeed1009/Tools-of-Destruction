using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class ChaosEnergy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaos Energy");
			Tooltip.SetDefault("The main part of the tools of destruction.");
		}

		public override void SetDefaults() 
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.maxStack = 999;
			item.rare = 4;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useTurn = false;
			item.autoReuse = false;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
	}
}