﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class Health
    {
        /* private list<Animationframe> frames..
         * const FPS = 60; bovenaan
         * 
         *                              gebruik ergens anders animation.addframe
         * 
         * in update
         CurrentFrame = frames[counter];
        secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
        if(secondCounter >= 1.0/FPS){
        counter++;
        secondCounter = 0;


        private void moveclasse(){
        
        positie += snelheid;
        if(positie.X > 800 || positie.X < 0)
        {
            snelheid.X *= -1;
        
        }
        if(positie.Y > 480 || positie.Y < 0)
        {
        snelheid.Y *= -1;
        }



        }
         
         
         */
        private Texture2D heart;

        private List<Texture2D> amountOfHealth;



        public Health() { }

        public void Load(ContentManager Content)
        {
            amountOfHealth = new List<Texture2D>();
            for (int i = 0; i < Player.Instance.HeartRate; i++)
            {
                amountOfHealth.Add(heart);
            }
            heart = Content.Load<Texture2D>("Health1");

        }
        public void Update(GameTime gameTime)
        {
            
           if(Player.Instance.HeartRate != amountOfHealth.Count) 
            {
                healthReduce();
            }
        


        }
        public void healthReduce()
        {
            amountOfHealth.RemoveAt(amountOfHealth.Count - 1);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < amountOfHealth.Count; i++)
            {
               
                    spriteBatch.Draw(heart, new Rectangle(i * 130, 0, 150, 100), Color.White);
                
                
            }
        }
    }
}
