using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.NPCs
{
	public class ChaosProbe : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Probe");

            Main.npcFrameCount[npc.type] = 1;
        }

		public override void SetDefaults() 
		{
            npc.width = 36;
            npc.height = 26;
            npc.damage = 50;
            npc.defense = 20;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath34;
            npc.value = 10f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Overworld.Chance * 0.2f;
            }
            else
            {
                return 0f;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float lifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.6);
            npc.damage = (int)(npc.damage * 1.3f);
        }

        public override void AI()
        {
            npc.rotation = (npc.velocity.X * 0.1f);
        }

        public override void NPCLoot()
        {
            {
                int amountPalladium = Main.rand.Next(3) + 1;
                int amountMythril = Main.rand.Next(2) + 1;
                int amountAdamantite = Main.rand.Next(1) + 1;
                int chanceQuarter = Main.rand.Next(3) + 1;
                int chanceTwentyFive = Main.rand.Next(1, 25);

                Item.NewItem(npc.position, ItemID.PalladiumBar, amountPalladium);

                if (chanceQuarter <= 2)
                {
                    Item.NewItem(npc.position, ItemID.MythrilBar, amountMythril);
                }

                if (chanceQuarter == 1)
                {
                    Item.NewItem(npc.position, ItemID.AdamantiteBar, amountAdamantite);
                }

                if (chanceTwentyFive == 1)
                {
                    Item.NewItem(npc.position, mod.ItemType("ChaoticBlaster"));
                }
            }
        }
	}
}