using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonogameProject.Classes.Score
{
    internal class ScoreHandler
    {
        private SpriteFont tekst;
        private ScoreStorage scoreStorage;

        // Factory pattern: dit constructor hier creëert en retourneert een instantie van de Score klasse.
        public ScoreHandler(SpriteFont tekst, ScoreStorage scoreStorage)
        {
            this.tekst = tekst;
            this.scoreStorage = scoreStorage;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(tekst, "Score: " + scoreStorage.Score, position, Color.White);
        }
    }
}
//SOLID principes:
// SRP: dit klasse heeft slechts één verantwoordelijkheid, namelijk het weergeven van de score
// LSP: het kan gebruikt worden als vervanging voor elke klasse die een score moet weergeven.

// Design patterns:
// - Factory pattern, zie deze constructor.



