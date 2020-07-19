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
using System.Net;

namespace Elenirmod.Items
{
    public class clipdeladestrucion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("El clip");
            Tooltip.SetDefault("Would you like help?");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.EngineeringHelmet, 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}