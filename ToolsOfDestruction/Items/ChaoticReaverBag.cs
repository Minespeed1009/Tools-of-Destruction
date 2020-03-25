using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class ChaoticReaverBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("ChaoticReaver");
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("<right> to open");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 10;
			item.consumable = true;
			item.rare = 6;
			item.expert = true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ItemID.GoldCoin, 10);
			player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
			player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(3, 7));
			player.QuickSpawnItem(mod.ItemType("FlameOfAnarchy"));
			int amountEnergy = Main.rand.Next(100) + 50;
			int dropItem = Main.rand.Next(4);
			if (dropItem == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ChaosTome"));
			}
			else if (dropItem == 1)
			{
				player.QuickSpawnItem(mod.ItemType("ChaoticShuriken"));
			}
			else if (dropItem == 2)
			{
				player.QuickSpawnItem(mod.ItemType("ChaoticCutter"));
			}
			else if (dropItem == 3)
			{
				player.QuickSpawnItem(mod.ItemType("ChaoticBoltCannon"));
			}
			player.QuickSpawnItem(mod.ItemType("ChaosEnergy"), amountEnergy);
		}
	}
}