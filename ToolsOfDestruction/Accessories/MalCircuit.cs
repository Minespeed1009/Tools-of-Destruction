using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Accessories
{

    public class MalCircuit : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malicious Circuitry");
            Tooltip.SetDefault("'A highly advanced AI chip, corrupted by an unknown force'\n20% increased damage\n+10 increased maximum health\n10% increased movement speed\nReleases a blast of energy when hit");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 0;
            item.rare = 6;
            item.accessory = true;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TODPlayer>().malcircuit = true;
            player.allDamage *= 1.2f;
            player.statLifeMax2 += 10;
            player.moveSpeed += 0.1f;
        }
    }
}