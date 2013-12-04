using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Smoke.View;

namespace Smoke.View
{
    class SmokeSystem
    {
        //Array för smoke-objekt
        private Smoke[] particles;
        //Antal Smoke-objekt
        private const int MAX_PARTICLES = 2000;

        //Initsierar arrayen med Smoke-objekt
        internal SmokeSystem(Vector2 startPossition, int scale)
        {
            particles = new Smoke[MAX_PARTICLES];

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i] = new Smoke(i, startPossition, scale);
            }
        }

        //Uppdaterar alla Smoke-objekt i arrayen
        internal void Update(float elapsedGameTime)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Update(elapsedGameTime);
            }
        }

        //Anropar Draw-metoden för alla Smoke-objekt i arrayen
        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Draw(spriteBatch, camera, texture);
            }
        }
    }
}
