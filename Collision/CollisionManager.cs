using MonogameProject.Classes.Hero;
using MonogameProject.Classes;
using MonogameProject.Tiles;
using MonogameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Collision
{
    internal class CollisionManager
    {
           for (int i = 0; i<coinLevel1.coins.Count; i++)
            {
                if (player.rectangle.Intersects(coinLevel1.coins[i]))
                {
                    coinLevel1.coins.RemoveAt(i);
                    score.ScoreUp();
       }
}
if (player.rectangle.Intersects(portal1.portals[0]))
{
    BioHunt.Instance.LevelStates = LevelStates.Level2;
}
foreach (CollisionTiles tile in mapLevel1.CollisionTiles)
{
    player.Collision(tile.Rectangle, mapLevel1.Width, mapLevel1.Height);
}
for (int i = 0; i < coinLevel2.coins.Count; i++)
{
    if (player.rectangle.Intersects(coinLevel2.coins[i]))
    {
        coinLevel2.coins.RemoveAt(i);
        score.ScoreUp();
    }
}
if (player.rectangle.Intersects(portal2.portals[0]))
{
    BioHunt.Instance.LevelStates = LevelStates.Level3;
}
foreach (CollisionTiles tile in mapLevel2.CollisionTiles)
{
    player.Collision(tile.Rectangle, mapLevel2.Width, mapLevel2.Height);
}
for (int i = 0; i < coinLevel3.coins.Count; i++)
{
    if (player.rectangle.Intersects(coinLevel3.coins[i]))
    {
        coinLevel3.coins.RemoveAt(i);
        score.ScoreUp();
    }
}

foreach (CollisionTiles tile in mapLevel3.CollisionTiles)
{
    player.Collision(tile.Rectangle, mapLevel3.Width, mapLevel3.Height);
}
if ((player.rectangle.Intersects(spook.rectangle) && LevelStates == LevelStates.Level1) || (player.rectangle.Intersects(boss.rectangle) && LevelStates == LevelStates.Level3) || (player.rectangle.Intersects(fish.rectangle) && LevelStates == LevelStates.Level2 || (player.rectangle.Intersects(lBall1.Rectangle) && LevelStates == LevelStates.Level2 || (player.rectangle.Intersects(lBall2.Rectangle) && LevelStates == LevelStates.Level2))))
            {
                if(player.isHit == false)
                {
                    player.isHit = true;
                    Player.Instance.HeartRate--;
                }

}
if ((player.rectangle.Intersects(spook.rectangle) && LevelStates == LevelStates.Level1))
{
    if (monsterHit == false)
    {
        monsterHit = true;

        spook.Velocity *= new Vector2(-1, 0);
    }
}
else if ((player.rectangle.Intersects(fish.rectangle) && LevelStates == LevelStates.Level2))
{
    if (monsterHit == false)
    {
        monsterHit = true;
        fish.Velocity *= new Vector2(-1, 0);
    }
}
if ((player.rectangle.Intersects(boss.rectangle) && player.rectangle.X - boss.rectangle.X < 0 && LevelStates == LevelStates.Level3)) //werkt niet
{
    if (monsterHit == false)
    {
        monsterHit = true;
        boss.VelocityX = -9;
        boss.VelocityX *= -1;

        boss.goLeft = false;
        boss.goRight = true;


    }
}
else if ((player.rectangle.Intersects(boss.rectangle) && player.rectangle.X - boss.rectangle.X > 0 && LevelStates == LevelStates.Level3))
{
    if (monsterHit == false)
    {
        monsterHit = true;

        boss.VelocityX = 9;
        boss.VelocityX *= -1;

        boss.goLeft = true;
        boss.goRight = false;
    }
}

if ((player.rectangle.X - boss.rectangle.X < -500) && LevelStates == LevelStates.Level3)
{
    boss.VelocityX = 9;
    boss.VelocityX *= -1;

    boss.goLeft = true;
    boss.goRight = false;
}
else if ((player.rectangle.X - boss.rectangle.X > 500) && LevelStates == LevelStates.Level3)
{
    boss.VelocityX = -9;
    boss.VelocityX *= -1;

    boss.goLeft = false;
    boss.goRight = true;
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


for (int i = 0; i < coinLevel2.coins.Count; i++)
{
    if (player.rectangle.Intersects(coinLevel2.coins[i]) && LevelStates == LevelStates.Level2)
    {
        coinLevel2.coins.RemoveAt(i);
        score.ScoreUp();
    }
}
for (int i = 0; i < coinLevel3.coins.Count; i++)
{
    if (player.rectangle.Intersects(coinLevel3.coins[i]) && LevelStates == LevelStates.Level3)
    {
        coinLevel3.coins.RemoveAt(i);
        score.ScoreUp();
    }
}


if (player.rectangle.Intersects(portal2.portals[0]) && LevelStates == LevelStates.Level2)
{
    LevelStates = LevelStates.Level3;
}



for (int i = 0; i < player.vuurbal.fireballRect.Count; i++)
{
    if (player.vuurbal.fireballRect[i].Intersects(spook.rectangle) && LevelStates == LevelStates.Level1)
    {
        spook.health -= 10;
        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
        player.vuurbal.aanmaakBullet = false;
        player.vuurbal.timer = 0;
        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
    }
    else if (player.vuurbal.fireballRect[i].Intersects(fish.rectangle) && LevelStates == LevelStates.Level2)
    {
        fish.health -= 10;
        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
        player.vuurbal.aanmaakBullet = false;
        player.vuurbal.timer = 0;
        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
    }
    else if (player.vuurbal.fireballRect[i].Intersects(boss.rectangle) && LevelStates == LevelStates.Level3)
    {
        boss.health -= 10;
        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
        player.vuurbal.aanmaakBullet = false;
        player.vuurbal.timer = 0;
        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
    }


}
    }
}
