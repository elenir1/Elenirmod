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
    public class Moonbargenhelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Visage");
            Tooltip.SetDefault(
                "While getting closer to the moon, 20% extra damage and crit chance\n" +
                "For those who live in the sky.");
        }


        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 16);
            item.rare = ItemRarityID.Red;
            item.defense = 25;
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
            if (player.velocity.Y < -3)
            {
                player.meleeDamage += 0.20f;
                player.meleeCrit += 20;
                player.magicDamage += 0.20f;
                player.magicCrit += 20;
                player.rangedDamage += 0.20f;
                player.rangedCrit += 20;
                player.thrownDamage += 0.20f;
                player.thrownCrit += 20;
            }
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemType<Moonbargenhelmet>()
                && body.type == ItemType<Moonbargenchestplate>()
                && legs.type == ItemType<Moonbargengreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Gain infinite flight time";
            player.wingTime = 30;

        }
    }
}
