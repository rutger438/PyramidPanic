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

namespace PyramidPanic
{
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        // Maak een variabele aan van het type playscene
        private PlayScene playScene;

        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Veranderd de titel van het canvas
            this.Window.Title = "Pyramid Panic";

            //Veranderd de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //Veranderd de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            this.IsMouseVisible = true;

            //Past de verandering toe
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //roept de update method aan van de Playscene object
            this.playScene = new PlayScene(this);

            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Keyboardstate gemaakt
            KeyboardState newState = Keyboard.GetState();
            //Sluit spel als op Esc word gedrukt
            if (newState.IsKeyDown(Keys.Escape)){
                Exit();
            }
            this.playScene.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Purple);

            //roep de begin() method aan van het spritebatch object
            this.spriteBatch.Begin();
            //roept de draw method aan van het startscene object
            this.playScene.Draw(gameTime);
            //roep de End() method aan van het spritebatch object
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
