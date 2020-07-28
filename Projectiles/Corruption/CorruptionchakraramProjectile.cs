using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Projectiles.Corruption
{
	public class CorruptionchakraramProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Corrupted Star");     //The English name of the projectile
		}

		public override void SetDefaults() {
			projectile.width = 38;               //The width of projectile hitbox
			projectile.height = 38;              //The height of projectile hitbox
			projectile.aiStyle = 3;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.melee = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 540;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.1f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?

		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
