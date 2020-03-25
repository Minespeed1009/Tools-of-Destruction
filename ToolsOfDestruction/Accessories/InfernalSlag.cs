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
    public class InfernalSlag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernal Slag");
            Tooltip.SetDefault("'All your foes shall fall to the Might of Fire'\n15% increased movement speed\n+10% damage\n+1 life regeneration");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 30;
            item.value = 0;
            item.rare = 4;
            item.accessory = true;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TODPlayer>().infslag = true;
            player.allDamage *= 1.10f;
            player.lifeRegen += 1;
            player.moveSpeed += 0.15f;
        }
    }
}