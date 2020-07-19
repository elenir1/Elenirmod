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
    [AutoloadEquip(EquipType.Body)]
    public class Eleaussiechestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aussie Chestplate");
            Tooltip.SetDefault(
                "10% increased melee damage\n" +
                "Perfect for adventures in the outback");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Blue;
            item.defense = 10;
        }

        public override void AddRecipes() //Tin
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(688, 1);
            recipe.AddIngredient(621, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Copper
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(80, 1);
            recipe.AddIngredient(621, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;
        }
    }
}
