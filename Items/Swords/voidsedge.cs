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

namespace Elenirmod.Items.Swords
{
    public class voidsedge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voids edge"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A wizard's trusty backup. Gain extra mana regen on hit");
        }

        public override void SetDefaults()
        {
            item.damage = 82;
            item.magic = true;
            item.width = 52;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 11000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            //Dyes
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 62, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += player.direction * 2f;
                Main.dust[dust].velocity.Y += 0.2f;

            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.HeldItem.type == ItemType<voidsedge>())
            {
                target.AddBuff(BuffID.ShadowFlame, 120);
                player.AddBuff(BuffType<Buffs.voidedgemanaregenbuff>(), 240);
            }
        }
    }
}