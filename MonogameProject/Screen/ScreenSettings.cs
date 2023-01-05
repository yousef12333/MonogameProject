using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Screen
{// zie comment in score
    internal class ScreenSettings
    {
       
            private static ScreenSettings instance;
            private int screenWidth = 1790;
            private int screenHeight = 703;

            public int ScreenWidth
            {
                get { return screenWidth; }
                set { screenWidth = value; }
            }

            public int ScreenHeight
            {
                get { return screenHeight; }
                set { screenHeight = value; }
            }

            private ScreenSettings() { }

            public static ScreenSettings Instance
            {
                get
                {
                    if (instance == null)
                        instance = new ScreenSettings();

                    return instance;
                }
            }
        }
}
//SOLID principes:
// SRP: dit klasse heeft slechts één verantwoordelijkheid, namelijk de scherminstellingen(screenwidth- of height enzo) opslaan.

// Design patterns:
// - Voldoet aan het Singleton patroon, omdat het ervoor zorgt dat er slechts één instantie van de klasse is en een globaal toegangspunt tot die instantie biedt.
// Dit zorgt ervoor dat er gebruik makend van dat instantie, het overal in de code kan worden benaderd via de Instance-eigenschap.
