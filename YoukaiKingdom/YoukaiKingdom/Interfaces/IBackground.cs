using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace YoukaiKingdom
{
    interface IBackground
    {
        void Load(GraphicsDevice device, Texture2D backgroundTexture);
        void Draw(SpriteBatch spriteBatch);
    }
}
