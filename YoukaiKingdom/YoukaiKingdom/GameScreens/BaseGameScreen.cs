using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace YoukaiKingdom.GameScreens
{
    public abstract class BaseGameScreen: DrawableGameComponent
    {
        protected MainGame mGame;

        public BaseGameScreen(MainGame mGame):base(mGame)
        {
            this.mGame = mGame;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
