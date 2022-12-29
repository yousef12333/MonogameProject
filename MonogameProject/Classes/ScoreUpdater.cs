﻿using MonogameProject.Classes;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{//zie comment in score class
    internal class ScoreUpdater
    {
            private ScoreStorage scoreStorage;

            //creëert en geeft een instantie van dit klasse terug
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
// LSP: dit klasse kan gebruikt worden als vervanging voor elke klasse die een score moet bijwerken.

// Design patterns:
// - Factory pattern, zie deze constructor.