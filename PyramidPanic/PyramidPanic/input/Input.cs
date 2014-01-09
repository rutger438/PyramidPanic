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
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        public static Rectangle mouseRect;
        private static GamePadState gps, ogps;
        
        static Input()
        {
            ks = Keyboard.GetState();
            gps = GamePad.GetState(PlayerIndex.One);
            ms = Mouse.GetState();
        }

        public static void Update()
        {
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
            ogps = gps;
            oks = ks;
            ks = Keyboard.GetState();
            gps = GamePad.GetState(PlayerIndex.One);
        }
        public static bool EdgeDetectKeyDown(Keys key)
        {
            //Dit is de edgedetector voor een willekeurige toets op het toetsenbord
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }
        public static bool EdgeDetectMousePressLeft()
        {
            //Dit is de edgedetector voor Linker muis knop, Hij werkt alleen als de oude state niet ingedrukt is dus ingedrukt houden van de knop doet niks.
            return ((ms.LeftButton == ButtonState.Pressed)&&(oms.LeftButton == ButtonState.Released));
        }
    }
}
