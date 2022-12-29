using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonogameProject.Classes
{
    internal class DamageDisplay
    {
        private SpriteFont font;
        private Vector2 position;
        private int damage;
        private float timer;
        private bool showDamage;

        public DamageDisplay(SpriteFont font)
        {
            this.font = font;
            this.position = new Vector2();
            this.damage = 0;
            this.timer = 0f;
            this.showDamage = false;
        }

        public void Update(GameTime gameTime)
        {
            if (showDamage)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                position.Y -= 1;

                if (timer >= 1f)
                {
                    showDamage = false;
                    timer = 0f;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (showDamage)
            {
                spriteBatch.DrawString(font, "-" + damage, position, Color.Red);
            }
        }

        public void DisplayDamage(Vector2 position, int damage)
        {
            this.position = position;
            this.damage = damage;
            showDamage = true;
        }
    }
}