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
        
        // Maak een variabele aan van het type endscene
        private EndScene endScene;

        // Maak een variabele aan van het type gameoverscene
        private GameOverScene gameOverScene;

        // Maak een variabele aan van het type helpscene
        private HelpScene helpScene;

        // Maak een variabele aan van het type playscene
        private PlayScene playScene;

        // Maak een variabele aan van het type startscene
        private StartScene startScene;

        // Maak een variabele aan van het type scoresscene
        private ScoresScene scoresScene;

        //De variabele die alle verschillende Scene-objecten kan bevatten is van het type IGameState dit is geen class maar een nieuw objecttype interface
        private IGameState gameState;

        //properties

        #region Properties
        //een property is om een private field buiten de class op te kunnen vragen
        //properties zijn in pascalcasing geschreven
        public IGameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }
        public EndScene EndScene
        {
            get { return this.endScene; }
        }
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }
        public StartScene StartScene
        {
            get { return this.startScene; }
        }
        public ScoresScene ScoresScene
        {
            get { return this.scoresScene; }
        }
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }
        #endregion

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
            //roept de update method aan van de endscene object
            this.endScene = new EndScene(this);
            //roept de update method aan van de gameoverscene object
            this.gameOverScene = new GameOverScene(this);
            //roept de update method aan van de helpscene object
            this.helpScene = new HelpScene(this);
            //roept de update method aan van de Playscene object
            this.playScene = new PlayScene(this);
            //roept de update method aan van de startscene object
            this.startScene = new StartScene(this);
            //roept de update method aan van de scoresscene object
            this.scoresScene = new ScoresScene(this);

            this.gameState = this.startScene;

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
            this.gameState.Update(gameTime);
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Purple);

            //roep de begin() method aan van het spritebatch object
            this.spriteBatch.Begin();
            //roept de draw method aan van het startscene object
            this.gameState.Draw(gameTime);
            //roep de End() method aan van het spritebatch object
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
