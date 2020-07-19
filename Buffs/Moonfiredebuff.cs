
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Elenirmod.Buffs
{
    public class Moonfiredebuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lunar flames");

            Description.SetDefault("Ouch");
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            // snow
            Dust d = Dust.NewDustDirect(player.position, player.width, player.height, 110, 0, 0.5f);
            d.velocity.Y -= 1f;
            d.noGravity = true;

                if (player.lifeRegen > 0) player.lifeRegen = 0;
                player.lifeRegenTime = 0;
            player.lifeRegen -= 30; 
            player.statDefense -= 15;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            // snow
            Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 110, 0, 0.5f);
            d.velocity.Y -= 1f;
            d.noGravity = true;


                if (npc.lifeRegen > 0) npc.lifeRegen = 0;
            npc.lifeRegen -= 30;
            npc.defense -= 15;

        }
    }
}
