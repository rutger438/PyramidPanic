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
    public class StartScene : IGameState
    {
        //Fields
        private PyramidPanic game;
        private Image background, title;
        //Constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
            this.LoadContent();
        }
        //Initialise
        protected void Initialize()
        {

        }
        //LoadContent
        public void LoadContent()
        {
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100, 35));
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
        }
        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.game.GameState = this.game.PlayScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.game.GameState = this.game.EndScene;
            }
        }
        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Cyan);
            this.background.Draw(gameTime);
            this.title.Draw(gameTime);
        }
    }
}
