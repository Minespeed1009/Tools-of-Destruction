using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ToolsOfDestruction.NPCs
{
	public class Drone : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rogue Amazon Drone");

            Main.npcFrameCount[npc.type] = 1;
        }

		public override void SetDefaults() 
		{
            npc.width = 44;
            npc.height = 18;
            npc.damage = 10;
            npc.defense = 8;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath34;
            npc.value = 10f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
        }

        public override void AI()
        {
            npc.rotation = (npc.velocity.X * 0.1f);
        }

        public override void NPCLoot()
        {
            {
                

                int amountCopper = Main.rand.Next(3) + 3;
                int amountIron = Main.rand.Next(4) + 1;
                int amountSilver = Main.rand.Next(2) + 1;
                int amountPlatinum = Main.rand.Next(1) + 1;
                int chanceQuarter = Main.rand.Next(3) + 1;
                int chanceTwentieth = Main.rand.Next(19) + 1;
                int chanceHundredth = Main.rand.Next(99) + 1;

                Item.NewItem(npc.position, ItemID.CopperBar, amountCopper);
                Item.NewItem(npc.position, ItemID.IronBar, amountIron);

                if (chanceQuarter <= 3)
                {
                    Item.NewItem(npc.position, ItemID.SilverBar, amountSilver);
                }

                if (chanceQuarter <= 2)
                {
                    Item.NewItem(npc.position, ItemID.PlatinumBar, amountPlatinum);
                }

                if (chanceTwentieth <= 2)
                {
                    if (WorldGen.crimson)
                    {
                        Item.NewItem(npc.position, ItemID.CrimtaneBar);
                    }
                    else
                    {
                        Item.NewItem(npc.position, ItemID.DemoniteBar);
                    }
                }

                if (chanceTwentieth == 1)
                {
                    Item.NewItem(npc.position, ItemID.LifeCrystal);
                }
                if (chanceHundredth == 1)
                {
                    Item.NewItem(npc.position, mod.ItemType("MalCircuit"));
                }
            }
        }
	}
}