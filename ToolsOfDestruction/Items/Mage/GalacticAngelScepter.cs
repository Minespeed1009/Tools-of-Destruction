using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Mage
{
	public class GalacticAngelScepter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Galactic Angel Scepter");

			Tooltip.SetDefault("'A scepter forged from the remains of the Horsehead Nebula'\nFires an orb of galactic power");

            Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.magic = true;
			item.width = 32;
			item.height = 32;
            item.mana = 15;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 6;
			item.useAnimation = 24;
			item.reuseDelay = 1;
			item.useTurn = false;
			item.rare = 5;
			item.autoReuse = true;
			item.knockBack = 3f;
			item.shoot = mod.ProjectileType("GASBoltProj");
			item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RemnantOfChaos"), 200);
            recipe.AddIngredient(ItemID.FragmentNebula, 25);
            recipe.AddIngredient(ItemID.Razorpine);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

			if (!(player.itemAnimation < item.useAnimation - 5))
			{
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GASOrbProj"), damage * 2, 0f, player.whoAmI);
				Main.PlaySound(SoundID.Item84, player.position);
				Main.PlaySound(SoundID.Item124, player.position);
			}

            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, 0f, player.whoAmI);
            }

            return false;
        }
	}
}