using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smoke.Model;
using Smoke.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Smoke.View
{
    class SmokeView
    {
        internal SmokeModel m_particleModel;
        internal Camera camera;
        internal GraphicsDevice graphicsDevice;
        internal SmokeSystem smokeSystem;
        internal SpriteBatch spriteBatch;
        internal Texture2D smokeTexture;

        //Konstruktor som initsierar alla variabler
        internal SmokeView(GraphicsDevice graphDevice, SmokeModel particleModel,
            ContentManager contentManager, Camera camera, SpriteBatch spriteBatch)
        {
            this.graphicsDevice = graphDevice;
            this.m_particleModel = particleModel;
            this.camera = camera;
            this.spriteBatch = spriteBatch;
            this.smokeSystem = new SmokeSystem(m_particleModel.Level.SmokePossition, camera.GetScale());

            LoadContent(contentManager);
        }

        //Funktion för att starta om rök-simuleringen
        internal void restart()
        {
            smokeSystem = new SmokeSystem(m_particleModel.Level.SmokePossition, camera.GetScale());
        }

        //Laddar texturen
        internal void LoadContent(ContentManager contentManager)
        {
            smokeTexture = contentManager.Load<Texture2D>("smoke");
        }

        //Anropar Update på smokeSystem-objektet
        internal void UpdateView(float elapsedGameTime)
        {
            smokeSystem.Update(elapsedGameTime);
        }

        internal void Draw(float elapsedGameTime)
        {
            graphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            //Anropar Draw på smokeSystem-objektet
            smokeSystem.Draw(spriteBatch, camera, smokeTexture);

            spriteBatch.End();
        }
    }
}
