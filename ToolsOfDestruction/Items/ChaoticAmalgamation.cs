using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Items
{
	public class ChaoticAmalgamation : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaotic Amalgamation");
			Tooltip.SetDefault("'A beacon of pure chaos, using this would certainly attract a powerful entity'\nSummons the Chaotic Reaver.");
		}

		public override void SetDefaults() 
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.maxStack = 20;
			item.rare = 4;
			item.useStyle = 4;
			item.useTime = 45;
			item.useAnimation = 45;
		}
		
		public override bool UseItem(Player player)
		{
			if(Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("ChaoticReaver"));
			}
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (!Main.dayTime && !NPC.AnyNPCs(mod.NPCType("ChaoticReaver")))
			{
				return true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ChaosEnergy"), 200);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}