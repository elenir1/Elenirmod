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
    [AutoloadEquip(EquipType.Head)]
    public class Eleaussiehelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aussie Helmet");
            Tooltip.SetDefault(
                "5% increased melee critical strike chance\n" +
                "G'day Mate");
        }


        public override void SetDefaults()
        {
            item.Size = new Vector2(18);
            item.value = Item.sellPrice(silver: 16);
            item.rare = ItemRarityID.Blue;
            item.defense = 9;
        }

        public override void AddRecipes() //Tin
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(687, 1);
            recipe.AddIngredient(621, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Copper
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(89, 1);
            recipe.AddIngredient(621, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 5;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemType<Eleaussiehelmet>()
                && body.type == ItemType<Eleaussiechestplate>()
                && legs.type == ItemType<ElenirKhakiarmouredshorts>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Player's boomerangs are buffed";
            //Wooden Boomerang extremely buffed
            if (player.HeldItem.type == ItemID.WoodenBoomerang)
            {
                player.meleeDamage += 1.5f;
                player.meleeCrit += 26;
                player.meleeSpeed += 1f;
                player.setBonus = "Double throw range, 26% Extra crit chance and 250% damage multiplier for Wooden Boomerang";
            }
            //Enchanted boomerang gets crit focused + falling stars
            if (player.HeldItem.type == ItemID.EnchantedBoomerang)
            {
                player.meleeDamage += 0.25f;
                player.meleeCrit += 45;
                player.meleeSpeed += 0.5f;
                player.AddBuff(BuffType<Buffs.EleboomerangStarbuff>(), 1);
                player.setBonus = "50% Extra throw range, faster recovery, 45% Extra crit chance and 25% damage multiplier for Enchanted Boomerang. Shoot stars with your boomerang";
            }
            // Ice Boomerang now slows down
            if (player.HeldItem.type == ItemID.IceBoomerang)
            {
                player.meleeDamage += 0.5f;
                player.meleeCrit += 5;
                player.AddBuff(BuffID.WeaponImbueNanites, 1);
                player.setBonus = "Confuse enemies on hit, 5% Extra crit chance and 50% damage multiplier for Ice Boomerang";
            }
            // Fire boomerang gets mild buffs
            if (player.HeldItem.type == ItemID.Flamarang)
            {
                player.meleeDamage += 0.2f;
                player.meleeCrit += 5;
                player.meleeSpeed += 0.1f;
                player.AddBuff(BuffID.Inferno, 1);
                player.setBonus = "10% extra range, 5% Extra crit chance and 20% damage multiplier for Flamarang. You are a walking wildfire!";
            }
        }
    }
}
