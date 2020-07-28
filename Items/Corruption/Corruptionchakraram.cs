using Elenirmod.Projectiles.Corruption;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Items.Corruption
{
    public class Corruptionchakraram : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Star");
            Tooltip.SetDefault("Throw boomerang-like stars at your enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 52;
            item.melee = true;
            item.noMelee = true;

            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 13500;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.noUseGraphic = true;
            item.width = 32;
            item.height = 32;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CorruptionchakraramProjectile");
            item.shootSpeed = 18f;
            item.channel = true;
        }

        public override void AddRecipes()
        {
            //altar and shit
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DaedalusStormbow, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlyingKnife, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalVileShard, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DartRifle, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChainGuillotines, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClingerStaff, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
