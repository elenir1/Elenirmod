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
    public class Arribaespana : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Arriba Espana");
            Description.SetDefault("Viva Antonio Lopez Castro");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            Main.meleeBuff[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}