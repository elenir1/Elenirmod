using Elenirmod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.NPCs
{
	public class ElenirmodGlobalNPC : GlobalNPC
	{
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                if (Main.rand.NextFloat() < .5f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Spears.LanceofCthulhu>(), 1);
            }

            if (npc.type == NPCID.BigMimicCorruption)
            {
                if (Main.rand.NextFloat() < .25f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Corruption.Corruptionchakraram>(), 1);
            }

            if (npc.type == NPCID.BigMimicCorruption)
            {
                if (Main.rand.NextFloat() < .15f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Corruption.Corruptionbow>(), 1);
            }

            if (npc.type == NPCID.Clinger)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Corruption.CursedRains>(), 1);
            }

            if (npc.type == NPCID.Corruptor)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Corruption.Summonercorruptionbook>(), 1);
            }
        }
	}
}