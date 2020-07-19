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
    public class Moonbargenchestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Chestplate");
            Tooltip.SetDefault(
                "Fly higher and attract hearts, money and mana\n" +
                "Enjoy the gravity of the moon");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Red;
            item.defense = 36;
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.jumpSpeedBoost += 1.0f;
            player.lifeMagnet = true;
            player.goldRing = true;
            player.manaMagnet = true;
        }
     }
}
