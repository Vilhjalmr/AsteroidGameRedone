using AsteroidGameRedone.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AsteroidGameRedone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Random rnd;

        Spaceship Ship;

        Texture2D background;
        List<Asteroid> Asteroids;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            Window.Title = "Asteroid";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Ship = new Spaceship(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight - graphics.PreferredBackBufferHeight / 10, 50, 50);
            Asteroids = new List<Asteroid>();

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

            // TODO: use this.Content to load your game content here
            rnd = new Random();

            Ship.Texture = Content.Load<Texture2D>("spaceship");
            LaserShot.Texture = Content.Load<Texture2D>("lasershot2");
            Asteroid.Texture = Content.Load<Texture2D>("spaceship");
            background = Content.Load<Texture2D>("background");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();

            Ship.Update(state, this.graphics);

            if (state.IsKeyDown(Keys.LeftAlt))
            {
                Asteroid ast = new Asteroid(rnd.Next(0, graphics.PreferredBackBufferWidth-60), 0 - Asteroid.Texture.Bounds.Height, 60, 60, 5);
                Asteroids.Add(ast);
            }

            foreach (var item in Asteroids)
            {
                item.Move(rnd);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            foreach (var item in Asteroids)
            {
                spriteBatch.Draw(Asteroid.Texture, item.Position, Color.White);
            }

            Ship.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
