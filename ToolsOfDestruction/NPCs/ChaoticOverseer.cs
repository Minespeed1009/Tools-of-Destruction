using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.NPCs
{
	public class ChaoticOverseer : ModNPC
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaotic Overseer");
        }

		public override void SetDefaults() 
		{
            npc.width = 32;
            npc.height = 40;
            npc.damage = 35;
            npc.defense = 10;
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
            return SpawnCondition.Dungeon.Chance * 0.1f;
        }

        public override void AI()
        {
            npc.rotation = npc.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
	}
}