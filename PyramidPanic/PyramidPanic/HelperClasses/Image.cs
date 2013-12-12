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
    public class Image
    {
        #region Fields
        //Fields zij private en zijn alleen binnen de class beschikbaar
        private Texture2D texture;
        //Met een texture2D kan je een plaatje zichtbaar maken. Is eigenlijk een soort houten bord waar je een pooster op kan plakken.
        private Rectangle rectangle;
        //De Rectange gebruiken we voor collition detection;
        private PyramidPanic game;
        //game geeft alle public variables van pyramid panic
        #endregion

        #region properties
        //Properties
        #endregion

        #region Constructor
        public Image(PyramidPanic game, String pathMainAsset, Vector2 position)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(pathMainAsset);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        } 
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {

        } 
        #endregion

        #region Draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.White);
        } 
        #endregion
    }
}
