using Terraria;
using Terraria.ModLoader;

namespace Elenirmod.Buffs
{
    public class voidedgemanaregenbuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Void's recovery");
            Description.SetDefault("Extra mana regeneration.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegen += 25; 
        }
    }
}
