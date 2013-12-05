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
        private static GamePadState gps, ogps;
        
        static Input()
        {
            ks = Keyboard.GetState();
            gps = GamePad.GetState(PlayerIndex.One);
        }

        public static void Update()
        {
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
    }
}
