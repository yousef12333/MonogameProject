

namespace MonogameProject.Classes.Score
{ //zie comment in Coin class
    internal class ScoreStorage
    {
        private static int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
//SOLID principes:
// SRP: dit klasse heeft slechts één verantwoordelijkheid, namelijk het opslaan van de score


