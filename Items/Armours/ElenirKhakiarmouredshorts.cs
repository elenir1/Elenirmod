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
    public class ElenirKhakiarmouredshorts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Khaki Shorts");
            Tooltip.SetDefault(
                "10% increased speed\n" +
                "Comes with stylish crocodile leather boots");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Blue;
            item.defense = 7;
        }

        public override void AddRecipes() //Tin
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(689, 1);
            recipe.AddIngredient(621, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Copper
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(76, 1);
            recipe.AddIngredient(621, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }
    }
}
