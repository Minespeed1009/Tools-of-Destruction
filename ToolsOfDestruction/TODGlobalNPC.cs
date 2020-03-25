using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToolsOfDestruction
{
	public class TODGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (Main.rand.Next(5) == 0 && npc.lifeMax >= 6 && !npc.friendly)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("ChaosEnergy"));
			}
			if (Main.rand.Next(5) == 0 && npc.lifeMax >= 6 && !npc.friendly && Main.player[Main.myPlayer].ZoneDungeon || npc.type == mod.NPCType("ChaoticOverseer"))
			{
				Item.NewItem(npc.getRect(), mod.ItemType("RemnantOfChaos"));
			}
			if (npc.type == NPCID.WallofFlesh && Main.rand.Next(2) == 0)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MoltenRock"));
			}
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.FindBuffIndex(mod.BuffType("ChaoticPotionBuff")) != -1)
			{
				spawnRate = (int)(spawnRate / 30f);
				maxSpawns = (int)(maxSpawns * 30f);
			}
		}
	}
}