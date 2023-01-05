using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;

namespace MonogameProject.Classes.Score
{
    internal class ScoreHandler : IScoreHandler
    {
        private SpriteFont tekst;
        private ScoreStorage scoreStorage;

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

// LSP: dit klasse volgt LSP omdat het de Draw methode van de Iscorehandler interface overridet
// op een manier die consistent is met het gedrag van de bovenliggende klasse. Dit betekent dat u een instantie van de klasse scorehandler
// overal kunt gebruiken waar een instantie van de Iscorehandler interface wordt verwacht, en dat deze zich op dezelfde
// manier gedraagt ​​als de bovenliggende klasse.

//DIP (Dependency Inversion Principle): het hangt af van de ScoreStorage en niet is gekoppeld aan specifieke implementaties van deze interfaces.

// Design patterns:
//Design pattern: DIP(Dependency Injection Pattern): de afhandelijkheden van andere klassen worden vervuld door de dependency the injecteren in de constructor
//zie ook scoreupdater klasse




