using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{ //zie comment in score class
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

// O/C Principe: het is open voor uitbreiding, maar gesloten voor wijziging. Aangezien het open is voor uitbreiding
// (bijvoorbeeld kan je methoden toevoegen om de score op te halen of de score op te slaan) maar gesloten voor wijziging (u zou de code in dit klasse niet moeten veranderen om nieuwe functionaliteit toe te voegen).

// LSP: dit klasse kan gebruikt worden als vervanging voor elke klasse die een score moet opslaan.
