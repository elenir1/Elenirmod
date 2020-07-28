using Elenirmod.Projectiles.Corruption;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Items.Corruption
{
    public class Corruptionbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bow Of Decay");
            Tooltip.SetDefault("Shoot 3 arrows at once.\n" +
                                "Arrows shot get turned into piercing flames.");
        }
        public override void SetDefaults()
        {
            item.damage = 66;
            item.ranged = true;
            item.noMelee = true;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.knockBack = 5;
            item.value = 13500;
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.noUseGraphic = false;
            item.width = 18;
            item.height = 50;
            item.autoReuse = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 24f;
            item.channel = true;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

                type = ProjectileID.CursedDartFlame;


            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 10 degree spread.
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot 


        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override void AddRecipes()
        {
            //anvil
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
