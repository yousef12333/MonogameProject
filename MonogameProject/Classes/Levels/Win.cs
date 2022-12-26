using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;



namespace MonogameProject.Classes.Levels
{
    internal class Win
    {
        private Texture2D winScreen;
        WinButton winEindigKnop;
        Rectangle mouseRectangle;
        private BioHunt game;
        public Score score;
        public ScoreUpdater scoreUpdater;
        public ScoreStorage scoreStorage;

        public Win(BioHunt game, SpriteFont scoreTekst)
        {
            scoreUpdater = new ScoreUpdater(scoreStorage);
            scoreStorage = new ScoreStorage();
            score = new Score(scoreTekst, scoreStorage);
            this.game = game;
        }
        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            winScreen = Content.Load<Texture2D>("Win_Background");
            winEindigKnop = new WinButton(Content.Load<Texture2D>("Quit_Button"), graphics);
            winEindigKnop.SetPosition(new Vector2((game.screenWidth / 2) - 90, 450));
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            if (winEindigKnop.isClicked == true) game.Exit();
            winEindigKnop.Update(mouse);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(winScreen, new Rectangle(0, 0, game.screenWidth + 80, game.screenHeight), Color.White);
            score.Draw(spriteBatch, new Vector2((game.screenWidth / 2) - 90, 350));
            winEindigKnop.Draw(spriteBatch);
        }
    }
}
