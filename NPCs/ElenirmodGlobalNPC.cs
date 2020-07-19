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
			if (npc.type == NPCID.CultistBoss) {
                if (Main.rand.NextFloat() < .5f)
                    Item.NewItem(npc.getRect(), ItemType<Items.Spears.LanceofCthulhu>(), 1);
			}
		}
	}
}