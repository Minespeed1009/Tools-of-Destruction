using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ToolsOfDestruction.Items.Mage
{
	public class ChaosTome : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chaos Tome");
		}

		public override void SetDefaults() 
		{
			item.damage = 97;
			item.magic = true;
			item.width = 32;
			item.height = 17;
            item.mana = 21;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 30;
			item.useAnimation = 30;
			item.rare = 5;
			item.autoReuse = true;
			item.UseSound = SoundID.Item8;
			item.crit = 25;
			item.knockBack = 2f;
			item.shoot = mod.ProjectileType("ChaosTomeProj"); 
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(SoundID.Item84, player.position);
			for (int i = 0; i < 6; i++)
			{
				Vector2 atkSpread = new Vector2(8f, 0f).RotatedBy(MathHelper.ToDegrees(70 * i));
				Projectile.NewProjectile(position.X, position.Y, atkSpread.X, atkSpread.Y, type, damage, 0f, player.whoAmI);
			}
			return false;
		}
	}
}