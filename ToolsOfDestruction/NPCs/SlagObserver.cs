using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.NPCs
{
	public class SlagObserver : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slag Observer");

            Main.npcFrameCount[npc.type] = 4;
        }

		public override void SetDefaults() 
		{
            npc.width = 27;
            npc.height = 11;
            npc.damage = 20;
            npc.defense = 12;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 10f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 2;
            npc.noGravity = true;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underworld.Chance * 0.25f;
        }

        public override void AI()
        {
            npc.rotation = npc.velocity.ToRotation() + MathHelper.ToRadians(90f);
            npc.spriteDirection = npc.direction = (npc.velocity.X > 0).ToDirectionInt();
        }

        int timer = 0;

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = timer / 5 * frameHeight;
            timer = timer + 1;
            if (timer == 15)
            {
                timer = 0;
            }
        }

        public override void NPCLoot()
        {
            {
                int amountHellstone = Main.rand.Next(1, 3);
                int chanceTenth = Main.rand.Next(1, 10);
                int chanceFiftieth = Main.rand.Next(1, 50);

                if (chanceFiftieth == 1)
                {
                    Item.NewItem(npc.position, mod.ItemType("InfernalSlag"));
                }

                if (chanceTenth == 1)
                {
                    Item.NewItem(npc.position, ItemID.HellstoneBar, amountHellstone);
                }
            }
        }
	}
}