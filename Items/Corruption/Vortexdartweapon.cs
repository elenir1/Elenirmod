using Elenirmod.Projectiles.Corruption;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Items.Corruption
{
    public class Vortexdartweapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Air Gun");
            Tooltip.SetDefault("25% chance not to consume ammo.\n" +
                                "Fire multiple darts at your enemies.");
        }
        public override void SetDefaults()
        {
            item.damage = 33;
            item.ranged = true;
            item.noMelee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 13500;
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.noUseGraphic = false;
            item.width = 70;
            item.height = 18;
            item.autoReuse = true;
            item.shoot = ProjectileID.CursedDart;
            item.shootSpeed = 25f;
            item.channel = true;
            item.useAmmo = AmmoID.Dart;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float num70 = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float num71 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
            float num87 = MathHelper.ToRadians(180);
            int num88 = 5;
            Vector2 vector = new Vector2(num70, num71);
            vector.Normalize();
            vector *= 40f;
            for (int num89 = 0; num89 < num88; num89++)
            {
                float num90 = (float)num89 - ((float)num88 - 1f) / 2f;
                Vector2 vector2 = vector.RotatedBy((double)(num87 * num90), default(Vector2));
                int num91 = Projectile.NewProjectile(position.X + vector2.X, position.Y + vector2.Y, speedX - num89, speedY - num89, type, damage, knockBack, Main.myPlayer);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16, 0);
        }

        public override void AddRecipes()
        {
            //Vortex
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .25f;
		}
    }
}
