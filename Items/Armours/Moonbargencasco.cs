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

namespace Elenirmod.Items.Armours
{
    [AutoloadEquip(EquipType.Head)]
    public class Moonbargencasco : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Helmet");
            Tooltip.SetDefault(
                "10% extra damage resistance. Full set provides builder bonuses\n" +
                "For those who live in the ground.");
        }


        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 16);
            item.rare = ItemRarityID.Red;
            item.defense = 28;
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
                player.endurance += 0.10f;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemType<Moonbargencasco>()
                && body.type == ItemType<Moonbargenchestplate>()
                && legs.type == ItemType<Moonbargengreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Applies an infinite builder and miner potion";
            player.AddBuff(BuffID.Builder, 1);
            player.AddBuff(BuffID.Mining, 1);

        }
    }
}
