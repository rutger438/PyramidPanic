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
    public interface IGameState
    {
        //Van de gameState variabele in de classs PyramidPanic willen we graag een update en draw methode kunnen aanroepen. dat kan alleen als je in de interface definitie dit aangeeft.
        //In een interface mag je geen public private etc. gebruiken je mag ook niet een method een body geven: {}
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
