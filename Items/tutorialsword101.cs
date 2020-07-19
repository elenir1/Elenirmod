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
    public class tutorialsword101 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("La Hispaniola"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots a phoenix that deals half the damage.");
        }

        public override void SetDefaults()
        {
            item.damage = 54;
            item.melee = true;
            item.width = 52;
            item.height = 60;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileID.DD2PhoenixBowShot;
            item.shootSpeed = 60f;
        }

        public override void AddRecipes()
        {
            //Dyes
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BreakerBlade, 1);
            recipe.AddIngredient(ItemID.RedDye, 2);
            recipe.AddIngredient(ItemID.YellowDye, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //Basic dye items

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BreakerBlade, 1);
            recipe.AddIngredient(ItemID.RedHusk, 2);
            recipe.AddIngredient(ItemID.YellowMarigold, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void HoldItem(Player player)
        {
            if (player.HeldItem.type == ItemType<tutorialsword101>())

            {
                if (!player.HasBuff(mod.BuffType("Arribaespana")))
                {
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Espanaarriba"));
                    player.AddBuff(BuffType<Buffs.Arribaespana>(), 120);
                }
                if (player.HasBuff(mod.BuffType("Arribaespana")))
                {
                    player.AddBuff(BuffType<Buffs.Arribaespana>(), 300);
                }
            }

        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.HeldItem.type == ItemType<tutorialsword101>())
            {
                target.AddBuff(BuffID.Ichor, 120);
                target.AddBuff(BuffID.OnFire, 60);
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity.X += player.direction * 2f;
                    Main.dust[dust].velocity.Y += 0.2f;
                
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            // Add random Rotation
            Vector2 speed = new Vector2(speedX, speedY);
            speed = speed.RotatedByRandom(MathHelper.ToRadians(15));
            // Change the damage since it is based off the weapons damage and is too high
            damage = (int)(damage * .50f);
            speedX = speed.X;
            speedY = speed.Y;
            return true;
        }
    }
}