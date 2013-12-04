using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Smoke.Model;
using Smoke.View;

namespace Smoke.Controller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class XNAController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Variabel för SmokeModel (Model)
        SmokeModel m_smokeModel;
        //Variabel för smokeView (View)
        SmokeView v_smokeView;
        //Variabel för Camera-objektet
        Camera camera;

        //Konstanter för logisk höjd och bredd på panelen
        public const float boardLogicWidth = 1.0f;
        public const float boardLogicHeight = 1.0f;

        //Konstanter för fönster-bredd och höjd
        public const int screenHeight = 800;
        public const int screenWidth = 800;

        public XNAController()
        {
            graphics = new GraphicsDeviceManager(this);
            //Sätter storlek på fönstret
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            m_smokeModel = new SmokeModel();
            //Gör så att muspekaren är synlig över fönstret
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Camera(graphics.GraphicsDevice.Viewport);

            v_smokeView = new SmokeView(graphics.GraphicsDevice, m_smokeModel, Content, camera, spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //Uppdaterar view
            v_smokeView.UpdateView((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Om man klickat i fönstret så startas röken om
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                v_smokeView.restart();
            }

            v_smokeView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Draw(gameTime);
        }
    }
}
