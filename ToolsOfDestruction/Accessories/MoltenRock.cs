using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToolsOfDestruction.Accessories
{
    public class MoltenRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'From the remains of the leader of hell, comes a fierce flame of lava.'\nAttacks set enemies on fire\nYou deal more damage to enemies that are on fire");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 38;
            item.value = 25000;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TODPlayer>().moltenrock = true;
        }
    }
}