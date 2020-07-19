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
using Elenirmod.Projectiles;

namespace Elenirmod.Items.Spears
{
    public class LanceofCthulhu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lance of Cthulhu"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault(
                "On hit spawn a chomper of Cthulhu, enemies hit with your lance will have their armour melt away\n" +
                "Remember to keep your distance.");
        }

        public override void SetDefaults()
        {
            item.damage = 121;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 14;
            item.useTime = 15;
            item.shootSpeed = 9.1f;
            item.knockBack = 8f;
            item.width = 80;
            item.height = 80;
            item.scale = 1f;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(silver: 10);

            item.melee = true;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileType<LanceofCthulhuProjectile>();
        }

        public override void AddRecipes()
        {
            //Post moonlord guaranted drop
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Imbue your spear with the power of the moon

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spear, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        

    }
}
