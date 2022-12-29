using Microsoft.Xna.Framework;
using MonogameProject.Classes.Levels;
using MonogameProject.Classes;


namespace MonogameProject.Collision
{
    internal class CollisionManager
    {
        //constantes voor een leesbaardere code
        private const int MONSTER_HIT_DURATION = 1;
        private const int PLAYER_FALL = 700;
        private const int PLAYER_DAMAGE = 10;
        private const int PLAYER_MIN_HEARTRATE = 1;

        public bool objectInitialized = false;
        float monsterHitCounter;
        bool monsterHit = false;
        public level1 level1;
        public level2 level2;
        public level3 level3;
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
            UpdateLevel1(gameTime);
            UpdateLevel2(gameTime);
            UpdateLevel3(gameTime);
            if (monsterHit == true)
            {
                monsterHitCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (monsterHitCounter > MONSTER_HIT_DURATION)
                {
                    monsterHit = false;
                    monsterHitCounter = 0;
                }
            }
        }
        public void UpdateLevel1(GameTime gameTime)
        {
            if (level1.player.rectangle.Intersects(level1.spook.rectangle))
            {
                if (level1.player.IsHit == false)
                {
                    level1.player.IsHit = true;
                    level1.player.HeartRate--;
                    if (Health.amountOfHealth.Count > 0)
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
                    level1.scoreUpdater.ScoreUp();
                }
            }

            for (int i = 0; i < level1.player.vuurbal.fireballRect.Count; i++)
            {
                if (level1.player.vuurbal.fireballRect[i].Intersects(level1.spook.rectangle))
                {
                    level1.spook.health -= PLAYER_DAMAGE;
                    level1.player.vuurbal.bullets.Remove(level1.player.vuurbal.bullets[i]);
                    level1.player.vuurbal.fireballRect.Remove(level1.player.vuurbal.fireballRect[i]);
                    level1.player.vuurbal.aanmaakBullet = false;
                    level1.player.vuurbal.timer = 0;
                    level1.player.vuurbal.directionFireball.RemoveAt(level1.player.vuurbal.directionFireball.Count - 1);
                    level1.damageDisplay.DisplayDamage(new Vector2(level1.spook.rectangle.X, level1.spook.rectangle.Y - 50), PLAYER_DAMAGE);
                }
            }

            if (level1.player.HeartRate < PLAYER_MIN_HEARTRATE || level1.player.Position.Y > PLAYER_FALL) 
            {
                game.LevelStates = LevelStates.Death;
            }

            if (game.LevelStates == LevelStates.Level1) 
            {
                if (level1.addedPortal == true && (level1.player.rectangle.Intersects(level1.portal1.portals[0])))
                {
                    game.LevelStates = LevelStates.Level2;
                    level2.shiftLevel = true;

                }
            }

        }
        public void UpdateLevel2(GameTime gameTime)
        {
            if (level2.player.rectangle.Intersects(level2.fish.rectangle) && game.LevelStates == LevelStates.Level2)
            {
                if (level2.player.IsHit == false)
                {
                    level2.player.IsHit = true;
                    level2.player.HeartRate--;
                    if (Health.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }
                if (monsterHit == false)
                {
                    monsterHit = true;
                    level2.fish.Velocity *= new Vector2(-1, 0);
                }

            }
            if (level2.player.rectangle.Intersects(level2.lBall1.Rectangle) && game.LevelStates == LevelStates.Level2)
            {
                if (level2.player.IsHit == false)
                {
                    level2.player.IsHit = true;
                    level2.player.HeartRate--;
                    if (Health.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }

            }
            if (level2.player.rectangle.Intersects(level2.lBall2.Rectangle) && game.LevelStates == LevelStates.Level2)
            {
                if (level2.player.IsHit == false)
                {
                    level2.player.IsHit = true;
                    level2.player.HeartRate--;
                    if (Health.amountOfHealth.Count > 0)
                        level2.playerLife.healthReduce();
                }

            }
            for (int i = 0; i < level2.coinLevel2.coins.Count; i++)
            {
                if (level2.player.rectangle.Intersects(level2.coinLevel2.coins[i]))
                {
                    level2.coinLevel2.coins.RemoveAt(i);
                    level2.scoreUpdater.ScoreUp();
                }
            }


            for (int i = 0; i < level2.player.vuurbal.fireballRect.Count; i++)
            {
                if (level2.player.vuurbal.fireballRect[i].Intersects(level2.fish.rectangle))
                {
                    level2.fish.health -= PLAYER_DAMAGE;
                    level2.player.vuurbal.bullets.Remove(level2.player.vuurbal.bullets[i]);
                    level2.player.vuurbal.fireballRect.Remove(level2.player.vuurbal.fireballRect[i]);
                    level2.player.vuurbal.aanmaakBullet = false;
                    level2.player.vuurbal.timer = 0;
                    level2.player.vuurbal.directionFireball.RemoveAt(level2.player.vuurbal.directionFireball.Count - 1);
                    level2.damageDisplay.DisplayDamage(new Vector2(level2.fish.rectangle.X, level2.fish.rectangle.Y - 50), PLAYER_DAMAGE);
                }
            }
            for (int i = 0; i < level2.player.vuurbal.fireballRect.Count; i++)
            {
                if (level2.player.vuurbal.fireballRect[i].Intersects(level2.lBall1.Rectangle))
                {

                    level2.player.vuurbal.bullets.Remove(level2.player.vuurbal.bullets[i]);
                    level2.player.vuurbal.fireballRect.Remove(level2.player.vuurbal.fireballRect[i]);
                    level2.player.vuurbal.aanmaakBullet = false;
                    level2.player.vuurbal.timer = 0;
                    level2.player.vuurbal.directionFireball.RemoveAt(level2.player.vuurbal.directionFireball.Count - 1);
                }
            }
            for (int i = 0; i < level2.player.vuurbal.fireballRect.Count; i++)
            {
                if (level2.player.vuurbal.fireballRect[i].Intersects(level2.lBall2.Rectangle))
                {
                    level2.fish.health -= PLAYER_DAMAGE;
                    level2.player.vuurbal.bullets.Remove(level2.player.vuurbal.bullets[i]);
                    level2.player.vuurbal.fireballRect.Remove(level2.player.vuurbal.fireballRect[i]);
                    level2.player.vuurbal.aanmaakBullet = false;
                    level2.player.vuurbal.timer = 0;
                    level2.player.vuurbal.directionFireball.RemoveAt(level2.player.vuurbal.directionFireball.Count - 1);
                }
            }
            if (level2.player.HeartRate < PLAYER_MIN_HEARTRATE)
            {

                game.LevelStates = LevelStates.Death;
            }

            if (game.LevelStates == LevelStates.Level2) 
            {
                if (level2.addedPortal == true && (level2.player.rectangle.Intersects(level2.portal2.portals[0])))
                {
                    game.LevelStates = LevelStates.Level3;
                    level3.shiftLevel = true;
                }
            }
        }
        public void UpdateLevel3(GameTime gameTime)
        {
            if (level3.player.rectangle.Intersects(level3.boss.rectangle))
            {
                if (level3.player.IsHit == false)
                {
                    level3.player.IsHit = true;
                    level3.player.HeartRate--;
                    if (Health.amountOfHealth.Count > 0)
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
                    level3.scoreUpdater.ScoreUp();
                }
            }
            for (int i = 0; i < level3.player.vuurbal.fireballRect.Count; i++)
            {
                if (level3.player.vuurbal.fireballRect[i].Intersects(level3.boss.rectangle))
                {
                    level3.boss.health -= PLAYER_DAMAGE;
                    level3.player.vuurbal.bullets.Remove(level3.player.vuurbal.bullets[i]);
                    level3.player.vuurbal.fireballRect.Remove(level3.player.vuurbal.fireballRect[i]);
                    level3.player.vuurbal.aanmaakBullet = false;
                    level3.player.vuurbal.timer = 0;
                    level3.player.vuurbal.directionFireball.RemoveAt(level3.player.vuurbal.directionFireball.Count - 1);
                    level3.damageDisplay.DisplayDamage(new Vector2(level3.boss.rectangle.X, level3.boss.rectangle.Y - 50), PLAYER_DAMAGE);
                }
            }

            if (level3.player.HeartRate < PLAYER_MIN_HEARTRATE)
            {
                game.LevelStates = LevelStates.Death;
            }
            if (level3.boss.health < 1)
            {
                game.LevelStates = LevelStates.Win;
            }
        }
        public CollisionManager()
        {

        }
    }
  } 
