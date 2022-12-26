using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Interfaces;
using MonogameProject.Screen;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class Score 
    {
        private SpriteFont tekst;
        private ScoreStorage scoreStorage;

        // Factory pattern: dit constructor hier creëert en retourneert een instantie van de Score klasse.
        public Score(SpriteFont tekst, ScoreStorage scoreStorage)
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



