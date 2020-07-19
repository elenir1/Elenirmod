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
    [AutoloadEquip(EquipType.Legs)]
    public class Moonbargengreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Leggings");
            Tooltip.SetDefault(
                "Wearer can run infinitely fast (Remember to remove any boot equipment)\n" +
                "15% increased speed, Extra Acceleration and jump speed, no fall damage\n" +
                "For those that need to get somewhere");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Red;
            item.defense = 21;
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 14);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            player.maxRunSpeed += 0.2f;
            player.accRunSpeed += 4.5f;
            player.jumpSpeedBoost += 1.5f;
            player.noFallDmg = true;
        }
    }
}
