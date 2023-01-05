

namespace MonogameProject.Classes.Score
{//zie comment in coin class
    internal class ScoreUpdater
    {
        private ScoreStorage scoreStorage;

        public ScoreUpdater(ScoreStorage scoreStorage)
        {
            this.scoreStorage = scoreStorage;
        }

        public void ScoreUp()
        {
            scoreStorage.Score++;
        }

    }
}
//SOLID principes:
// SRP: dit klasse heeft slechts één verantwoordelijkheid, dat is de score aanpassen(verhogen met 1).
//DIP (Dependency Inversion Principle): Dit klasse is afhankelijk van de ScoreStorage en is niet gekoppeld aan
//een specifieke implementatie van de ScoreStorage klasse. Dit betekent dat u eenvoudig de implementatie van ScoreStorage die de
//ScoreUpdater klasse gebruikt, kunt omwisselen zonder de ScoreUpdater klasse zelf te wijzigen.
// Design patterns:
//Design pattern: DIP(Dependency Injection Pattern): de afhandelijkheden van andere klassen worden vervuld door de dependency the injecteren in de constructor
//zie ook scorehandler klasse

