using Elenirmod.Projectiles.Corruption;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Items.Corruption
{
    public class Summonercorruptionbook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Words Of Corruption");
            Tooltip.SetDefault("Summon an army of eaters to attack your enemies.\n" +
                                "Eaters don't use minion slots." );
        }
        public override void SetDefaults()
        {
            item.damage = 26;
            item.summon = true;
            item.noMelee = true;
            item.mana = 8;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 13500;
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.noUseGraphic = false;
            item.width = 32;
            item.height = 32;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Corruptchomp");
            item.shootSpeed = 20f;
            item.channel = true;
        }

        public override void AddRecipes()
        {
            //Book
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
