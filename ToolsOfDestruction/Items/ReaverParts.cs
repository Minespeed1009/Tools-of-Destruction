using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class ReaverParts : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Reaver Parts");
			Tooltip.SetDefault("'Parts of the god of destruction.'");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.maxStack = 99;
			item.rare = 5;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useTurn = false;
			item.autoReuse = false;
		}
	}
}