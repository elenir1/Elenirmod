using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Buffs
{
    public class EleboomerangStarbuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eureka!");
            Description.SetDefault("Your attacks are enchanted with star power");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            Main.meleeBuff[Type] = false;
            Main.persistentBuff[Type] = true;
        }
    }

    public class EleboomerangStarbuffhit : GlobalNPC
    {

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (Main.player[projectile.owner].HasBuff(mod.BuffType("EleboomerangStarbuff")) && projectile.melee)
            {
                Projectile.NewProjectile(projectile.position, new Vector2(-projectile.velocity.X, -projectile.velocity.Y), ProjectileID.HallowStar, (projectile.damage * 3) / 8, projectile.knockBack / 1f, projectile.owner, 0f, 0f);
            }
        }
    }
}