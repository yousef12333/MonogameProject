using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.Devices;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;
using MonogameProject.ViewStates;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.Direct3D9;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Content;
using MonogameProject.Screen;
using MonogameProject.Classes.Levels;
using MonogameProject.Classes;
using SharpDX.MediaFoundation;


namespace MonogameProject.Collision
{
    internal class CollisionManager
    {
      

        public bool objectInitialized = false;

        bool levelLoaded = true;
        float monsterHitCounter;
        bool monsterHit = false;
        public level1 level1;
        public level2 level2;
        public level3 level3;
        bool freeze2 = true;
        bool freeze3 = true;
        private BioHunt game;



        private static CollisionManager instance;

        public static CollisionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CollisionManager();

                return instance;
            }
        }
        public CollisionManager(BioHunt game)
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {

            if (level1.player.rectangle.Intersects(level1.spook.rectangle))
            {
                if (level1.player.isHit == false)
                {
                    level1.player.isHit = true;
                    level1.player.HeartRate--;
                    if (level1.playerLife.amountOfHealth.Count > 0)
                        level1.playerLife.healthReduce();
                }
                if (monsterHit == false)
                {
                    monsterHit = true;

                    level1.spook.Velocity *= new Vector2(-1, 0);
                }

            }
            for (int i = 0; i < level1.coinLevel1.coins.Count; i++)
            {
                if (level1.player.rectangle.Intersects(level1.coinLevel1.coins[i]))
                {
                    level1.coinLevel1.coins.RemoveAt(i);
                    level1.score.ScoreUp();
                }
            }

            for (int i = 0; i < level1.player.vuurbal.fireballRect.Count; i++)
            {
                if (level1.player.vuurbal.fireballRect[i].Intersects(level1.spook.rectangle))
                {
                    level1.spook.health -= 10;
                    level1.player.vuurbal.bullets.Remove(level1.player.vuurbal.bullets[i]);
                    level1.player.vuurbal.fireballRect.Remove(level1.player.vuurbal.fireballRect[i]);
                    level1.player.vuurbal.aanmaakBullet = false;
                    level1.player.vuurbal.timer = 0;
                    level1.player.vuurbal.directionFireball.RemoveAt(level1.player.vuurbal.directionFireball.Count - 1);
                }
            }
            if (level1.player.HeartRate < 1)
            {
                game.LevelStates = LevelStates.Death;
            }
            if (level1.addedPortal == true && (level1.player.rectangle.Intersects(level1.portal1.portals[0]))) // portals hier ------------------------
            {
                game.LevelStates = LevelStates.Level2;
                level2.playerFrozen = false;


            }






            if (level2.player.rectangle.Intersects(level2.fish.rectangle))
            {
                if (level2.player.isHit == false)
                {
                    level2.player.isHit = true;
                    level2.player.HeartRate--;
                    if (level2.playerLife.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }

            }
            if (level2.player.rectangle.Intersects(level2.lBall1.Rectangle))
            {
                if (level2.player.isHit == false)
                {
                    level2.player.isHit = true;
                    level2.player.HeartRate--;
                    if (level2.playerLife.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }

            }
            if (level2.player.rectangle.Intersects(level2.lBall2.Rectangle))
            {
                if (level2.player.isHit == false)
                {
                    level2.player.isHit = true;
                    level2.player.HeartRate--;
                    if (level2.playerLife.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }

            }


            if (level2.player.rectangle.Intersects(level2.fish.rectangle))
            {
                if (monsterHit == false)
                {
                    monsterHit = true;
                    level2.fish.Velocity *= new Vector2(-1, 0);
                }
            }
            for (int i = 0; i < level2.coinLevel2.coins.Count; i++)
            {
                if (level2.player.rectangle.Intersects(level2.coinLevel2.coins[i]))
                {
                    level2.coinLevel2.coins.RemoveAt(i);
                    level2.score.ScoreUp();
                }
            }


            for (int i = 0; i < level2.player.vuurbal.fireballRect.Count; i++)
            {
                if (level2.player.vuurbal.fireballRect[i].Intersects(level2.fish.rectangle))
                {
                    level2.fish.health -= 10;
                    level2.player.vuurbal.bullets.Remove(level2.player.vuurbal.bullets[i]);
                    level2.player.vuurbal.fireballRect.Remove(level2.player.vuurbal.fireballRect[i]);
                    level2.player.vuurbal.aanmaakBullet = false;
                    level2.player.vuurbal.timer = 0;
                    level2.player.vuurbal.directionFireball.RemoveAt(level2.player.vuurbal.directionFireball.Count - 1);
                }
            }
            if (level2.player.HeartRate < 1)
            {

                game.LevelStates = LevelStates.Death;
            }
            if (level2.addedPortal == true && (level2.player.rectangle.Intersects(level2.portal2.portals[0])))
            {
                game.LevelStates = LevelStates.Level3;
                level3.playerFrozen = false;

            }





            if (level3.player.rectangle.Intersects(level3.boss.rectangle))
            {
                if (level3.player.isHit == false)
                {
                    level3.player.isHit = true;
                    level3.player.HeartRate--;
                    if (level3.playerLife.amountOfHealth.Count > 0)
                        level3.playerLife.healthReduce();
                }

            }


            if (level3.player.rectangle.Intersects(level3.boss.rectangle) && level3.player.rectangle.X - level3.boss.rectangle.X < 0)
            {
                if (monsterHit == false)
                {
                    monsterHit = true;
                    level3.boss.VelocityX = -9;
                    level3.boss.VelocityX *= -1;

                    level3.boss.goLeft = false;
                    level3.boss.goRight = true;


                }
            }
            else if (level3.player.rectangle.Intersects(level3.boss.rectangle) && level3.player.rectangle.X - level3.boss.rectangle.X > 0)
            {
                if (monsterHit == false)
                {
                    monsterHit = true;

                    level3.boss.VelocityX = 9;
                    level3.boss.VelocityX *= -1;

                    level3.boss.goLeft = true;
                    level3.boss.goRight = false;
                }
            }

            if (level3.player.rectangle.X - level3.boss.rectangle.X < -500)
            {
                level3.boss.VelocityX = 9;
                level3.boss.VelocityX *= -1;

                level3.boss.goLeft = true;
                level3.boss.goRight = false;
            }
            else if (level3.player.rectangle.X - level3.boss.rectangle.X > 500)
            {
                level3.boss.VelocityX = -9;
                level3.boss.VelocityX *= -1;

                level3.boss.goLeft = false;
                level3.boss.goRight = true;
            }
            for (int i = 0; i < level3.coinLevel3.coins.Count; i++)
            {
                if (level3.player.rectangle.Intersects(level3.coinLevel3.coins[i]))
                {
                    level3.coinLevel3.coins.RemoveAt(i);
                    level3.score.ScoreUp();
                }
            }
            for (int i = 0; i < level3.player.vuurbal.fireballRect.Count; i++)
            {
                if (level3.player.vuurbal.fireballRect[i].Intersects(level3.boss.rectangle))
                {
                    level3.boss.health -= 10;
                    level3.player.vuurbal.bullets.Remove(level3.player.vuurbal.bullets[i]);
                    level3.player.vuurbal.fireballRect.Remove(level3.player.vuurbal.fireballRect[i]);
                    level3.player.vuurbal.aanmaakBullet = false;
                    level3.player.vuurbal.timer = 0;
                    level3.player.vuurbal.directionFireball.RemoveAt(level3.player.vuurbal.directionFireball.Count - 1);
                }
            }

            if (level3.player.HeartRate < 1)
            {
                game.LevelStates = LevelStates.Death;
            }
            if (level3.boss.health < 1)
            {
                game.LevelStates = LevelStates.Win;
            }



            if (monsterHit == true)
            {
                monsterHitCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (monsterHitCounter > 1)
                {
                    monsterHit = false;
                    monsterHitCounter = 0;
                }
            }

        }
        public CollisionManager()
        {

        }
    }
  } 
