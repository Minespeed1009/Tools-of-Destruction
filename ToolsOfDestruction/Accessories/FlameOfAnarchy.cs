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
    public class FlameOfAnarchy : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Of Anarchy");
            Tooltip.SetDefault("Attacks have a chance to fire a reaver probe");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 32;
            item.value = 0;
            item.rare = 6;
            item.accessory = true;
            item.defense = 5;
            item.expert = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TODPlayer>().reaverExpertAcc = true;
        }
    }
}