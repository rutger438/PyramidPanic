using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class Menu
    {
        #region Fields
        Image startButton, loadButton, quitButton, helpButton, scoresButton;
        PyramidPanic game;
        List<Image>buttonList = new List<Image>();
        #endregion

        #region Properties
        
        #endregion

        #region Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            Initialize();
        }
        #endregion

        public void LoadContent()
        {
            buttonList.Add(
            this.startButton = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 440f)));
            buttonList.Add(
            this.loadButton = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 440f)));
            buttonList.Add(
            this.helpButton = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 440f)));
            buttonList.Add(
            this.scoresButton = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 440f)));
            buttonList.Add(
            this.quitButton = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 440f)));
        }
        public void Initialize()
        {
            LoadContent();
        }

        #region Update
        
        #endregion

        #region Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.buttonList)
            {
                image.Draw(gameTime);
            }
        }
        #endregion
    }
}
