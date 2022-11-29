using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;
using MonogameProject.ViewStates;
using MonogameProject.Classes.Hero;
using MonogameProject.Screen;


namespace MonogameProject.Classes.Levels
{
    internal class Win
    {
        Player player;
        Ufo ufo;
        public DeathButton restart;
        public Texture2D backgroundDeath;
        public MenuButtons btnPlay;
        GraphicsDevice grap;
        private Texture2D winScreen;
        WinButton winEindigKnop;
        BioHunt biohunt;
        public Win()
        {
            biohunt = new BioHunt();
        }
        public void Load(ContentManager Content)
        {
           
            winScreen = Content.Load<Texture2D>("Win_Background");
            winEindigKnop = new WinButton(Content.Load<Texture2D>("Quit_Button"), biohunt.GraphicsDevice);
            winEindigKnop.SetPosition(new Vector2(640, 450));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundDeath, new Rectangle(0, 0, ScreenSettings.Instance.screenWidth + 80, ScreenSettings.Instance.screenHeight), Color.White);
            restart.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (winEindigKnop.isClicked == true) BioHunt.Instance.Exit();
            winEindigKnop.Update(mouse);



        }
    }
}
