using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Elenirmod.Projectiles
{


	internal class Cthulhuchomp : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.penetrate = -1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffType<Buffs.Moonfiredebuff>(), 300);
		}

		public override Color? GetAlpha(Color lightColor) {
			//return Color.White;
			return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
		}

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 50f)
            {
                // Fade out
                projectile.alpha += 25;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
            }
            else
            {
                // Fade in
                projectile.alpha -= 25;
                if (projectile.alpha < 100)
                {
                    projectile.alpha = 100;
                }
            }
            // Slow down
            projectile.velocity *= 1.05f;
            // Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            // Kill this projectile after 1 second
            if (projectile.ai[0] >= 60f)
            {
                projectile.Kill();
            }
            projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            // Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi;
            }

			if (Main.rand.NextBool(3))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 229,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, new Color(0, 255, 17), Scale: 1f);
				dust.velocity += projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4))
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 229,
					0, 0, 254, new Color(0, 255, 17), Scale: 0.2f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}

		// Some advanced drawing because the texture image isn't centered or symetrical.
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 20 : 20);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

			return false;
		}
	}
}
