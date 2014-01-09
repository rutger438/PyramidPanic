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
        //We maken een variablele aan van het type button. deze variablele kan maar 5 waarden hebben. we kunne altijd nieuwe toevoegen.
        PyramidPanic game;
        List<Image>buttonList = new List<Image>();
        private enum Button { Start, Load, Help, Scores, Quit };
        private Button buttonState = Button.Start;
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

            this.startButton.Color = Color.Gold;
        }
        public void Initialize()
        {
            LoadContent();
        }

        #region Update
        public void Update(GameTime gameTime)
        {
            MouseState mState;
            mState = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(mState.X, mState.Y, 2, 2);
            if (mouseRect.Intersects(helpButton.Rectangle))
            {
                this.helpButton.Color = Color.Gold;
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    game.GameState = game.HelpScene;
                }
            }
            else
            {
                this.helpButton.Color = Color.White;
            }
            if (Input.EdgeDetectKeyDown(Keys.Right) && buttonState != Button.Quit)
            {
                buttonState++;
                foreach (Image button in this.buttonList)
                {
                    button.Color = Color.White;
                }
            }
            if (Input.EdgeDetectKeyDown(Keys.Left) && buttonState != Button.Start)
            {
                buttonState--;
                foreach (Image button in this.buttonList)
                {
                    button.Color = Color.White;
                }
            }
            switch (this.buttonState)
            {
                case Button.Start:
                    this.startButton.Color = Color.Gold;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        game.GameState = game.PlayScene;
                    }
                    break;
                case Button.Load:
                    this.loadButton.Color = Color.Gold;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        game.GameState = game.LoadScene;
                    }
                    break;
                case Button.Help:
                    this.helpButton.Color = Color.Gold;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        game.GameState = game.HelpScene;
                    }
                    break;
                case Button.Scores:
                    this.scoresButton.Color = Color.Gold;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.ScoresScene;
                    }
                    break;
                case Button.Quit:
                    this.quitButton.Color = Color.Gold;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        game.Exit();
                    }
                    break;
            }
        }
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
