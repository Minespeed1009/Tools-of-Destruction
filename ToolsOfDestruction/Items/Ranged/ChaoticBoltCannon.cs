using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Ranged
{
	public class ChaoticBoltCannon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Fires a burst of chaos energy");
		}

		public override void SetDefaults() 
		{
			item.damage = 87;
			item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 20; 
			item.useAnimation = 20;
			item.rare = 6;
			item.autoReuse = true;
			item.knockBack = 10f;
			item.shoot = mod.ProjectileType("ChaoticBolt");
			item.shootSpeed = 18f;
			item.crit = 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Main.PlaySound(SoundID.Item109, player.position);
			for (int i = 0; i < 4; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 0f, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
	}
}