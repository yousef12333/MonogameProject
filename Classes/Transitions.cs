using Microsoft.Xna.Framework;
using MonogameProject.Classes.Levels;
using MonogameProject.Classes;
using MonogameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MonogameProject.Classes.Hero;
using System.IO;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.Classes
{
    internal class Transitions
    {
        Win win;
        Death death;
        MainMenu mainMenu;
        BossMonster boss;
        
        public void Update(GameTime gameTime)
        {
            if (Player.Instance.HeartRate < 1)
            {
                BioHunt.Instance.LevelStates = LevelStates.Death;
            }
            else if (boss.health < 1)
            {
                BioHunt.Instance.LevelStates = LevelStates.Win;
            }
            switch (BioHunt.Instance.LevelStates)
            {
                case LevelStates.MainMenu:
                    mainMenu.Update(gameTime);
                    break;
                case LevelStates.Level1:
                    if (Keyboard.GetState().IsKeyDown(Keys.A)) { BioHunt.Instance.LevelStates = LevelStates.Death; }
                    if (Keyboard.GetState().IsKeyDown(Keys.R)) BioHunt.Instance.LevelStates = LevelStates.Level2;
                    if (Level2.Instance.portal2.teleported == true)
                    {
                        BioHunt.Instance.LevelStates = LevelStates.Level2;
                    }
                    break;
                case LevelStates.Level2:
                    if (Keyboard.GetState().IsKeyDown(Keys.T)) { BioHunt.Instance.LevelStates = LevelStates.Level3; }
                    if (Keyboard.GetState().IsKeyDown(Keys.U))
                    {
                        BioHunt.Instance.LevelStates = LevelStates.Death;
                    }
                    break;
                case LevelStates.Level3:
                    if (Keyboard.GetState().IsKeyDown(Keys.P)) { BioHunt.Instance.LevelStates = LevelStates.Win; }

                    break;
                case LevelStates.Win:
                    win.Update(gameTime);
                    break;
                case LevelStates.Death:
                    death.Update(gameTime);
                    break;

            }
        }
     

        }
    } 


