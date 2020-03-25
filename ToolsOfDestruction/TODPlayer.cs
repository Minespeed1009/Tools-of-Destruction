using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace ToolsOfDestruction
{
    public class TODPlayer : ModPlayer
    {
        public bool malcircuit = false;
        public bool reaverExpertAcc = false;
        public bool moltenrock = false;
        
        public override void ResetEffects()
        {
            malcircuit = false;
            infslag = false;
            reaverExpertAcc = false;
            moltenrock = false;
        }

        public bool infslag = false;

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (malcircuit)
            {
                for (int i = 0; i < (24); i++)
                {
                    int num2 = Dust.NewDust(player.position, player.width, player.height, 92, 0, 0, 0, default(Color), 1f);
                    Main.dust[num2].velocity *= 2f;
                }
                for (int i = 0; i < 6; i++)
                {
                    float speedX = Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-8f, 8f);
                    float speedY = Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                    Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, mod.ProjectileType("MalCircuitEnergy"), (int)(16), 0f, 0, 0f, 0f);
                    Main.PlaySound(SoundID.NPCHit53, player.position);
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (moltenrock)
            {
                if (target.FindBuffIndex(BuffID.OnFire) != -1)
                {
                    damage = (int)(damage * 1.5f);
                }
                target.AddBuff(BuffID.OnFire, 300);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (moltenrock)
            {
                if (target.FindBuffIndex(BuffID.OnFire) != -1)
                {
                    damage = (int)(damage * 1.5f);
                }
                target.AddBuff(BuffID.OnFire, 300);
            }
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(reaverExpertAcc == true && Main.rand.Next(4) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ChaosProbeMini"), damage * 2, 0f, player.whoAmI);
            }
            return true;
        }
    }
}