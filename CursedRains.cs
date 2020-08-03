using Elenirmod.Projectiles.Corruption;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Items.Corruption
{
    public class CursedRains : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Rain");
            Tooltip.SetDefault("Cursed Flames will rain on your enemies.");
        }
        public override void SetDefaults()
        {
            item.damage = 45;
            item.magic = true;
            item.noMelee = true;
            item.mana = 10;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 13500;
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.noUseGraphic = false;
            item.width = 32;
            item.height = 32;
            item.autoReuse = true;
            item.shoot = ProjectileID.CursedDartFlame;
            item.shootSpeed = 20f;
            item.channel = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 1, knockBack, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }

        public override void AddRecipes()
        {
            //Book
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
