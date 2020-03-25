using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.NPCs
{
	public class CursedHammer : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Mjolnir");

            Main.npcFrameCount[npc.type] = 1;
        }

		public override void SetDefaults() 
		{
            npc.width = 36;
            npc.height = 36;
            npc.damage = 25;
            npc.defense = 25;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath34;
            npc.value = 10f;
            npc.knockBackResist = 1f;
            npc.aiStyle = 23;
            npc.noGravity = true;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Underground.Chance * 0.05f;
            }
            else
            {
                return 0f;
            }
        }

        public override void NPCLoot()
        {
            {
                int chanceTwentieth = Main.rand.Next(19) + 1;

                if (chanceTwentieth == 1)
                {
                    Item.NewItem(npc.position, mod.ItemType("Mjolnir"));
                }
            }
        }
	}
}