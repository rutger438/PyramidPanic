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
        //Constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }
        //Initialise
        protected void Initialize()
        {

        }
        //LoadContent
        public void LoadContent()
        {

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
        }
    }
}
