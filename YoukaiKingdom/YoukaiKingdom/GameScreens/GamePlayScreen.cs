using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using YoukaiKingdom.Sprites;
using YoukaiKingdom.GameLogic;
using YoukaiKingdom.Helpers;

namespace YoukaiKingdom.GameScreens
{
    public class GamePlayScreen: BaseGameScreen
    {
        #region Fields

        //textures
        Texture2D playerSprite;
        //sprites
        Player mPlayer;
        StillSprite castle01;
        //background
        Background mBackground;
        
        Camera camera;
        //for Camera
        public Vector2 playerPosition;
        public Rectangle playerRectangle;
        public int worldWidth;
        public int worldHeight;
        
        public List<Rectangle> collisionRectangles;
        // ^ add all sprites from game screen to the list here
        //later probably invent somethin better

        #endregion

        #region Constructors

        public GamePlayScreen(MainGame mGame):base(mGame)
        {
            camera = new Camera(mGame.GraphicsDevice.Viewport);
            collisionRectangles = new List<Rectangle>();
        }

        #endregion

        #region Methods

        public override void Initialize()
        { 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(mGame.GraphicsDevice);

            mBackground = new Background();
            Texture2D background = mGame.Content.Load<Texture2D>("Sprites/Backgrounds/Background01");
            Texture2D castleTexture = mGame.Content.Load<Texture2D>("Sprites/Environment/Castle");

            //PLAYER
            playerSprite = mGame.Content.Load<Texture2D>("Sprites/PlayerClasses/female_ninja");
            //right now only this one, 
            //later will be selected depending of class

            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 48, 64, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 48, 64, 0, 64);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 48, 64, 0, 128);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 48, 64, 0, 192);
            animations.Add(AnimationKey.Up, animation);

            mPlayer = new Player(playerSprite, animations);

            //set up castle
            castle01 = new StillSprite(castleTexture);

            mPlayer.Position = new Vector2(100, 300);
            castle01.Position = new Vector2(100, 100);
            //add castle to the list of collisions
            collisionRectangles.Add(new Rectangle
                ((int)castle01.Position.X, (int)castle01.Position.Y,
                castleTexture.Width, castleTexture.Height));

            mBackground.Load(mGame.GraphicsDevice, background);
            worldHeight = mBackground.WorldHeight;
            worldWidth = mBackground.WorldWidth;
        }

        public override void Update(GameTime gameTime)
        {
            mPlayer.Update(gameTime, this);
            //define current position of the player for the camera to follow
            playerPosition = mPlayer.Position;
            playerRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y,
                48, 64);
            camera.Update(gameTime, this);
        }

        public override void Draw(GameTime gameTime)
        {            
            mGame.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            mBackground.Draw(mGame.spriteBatch);
            //things are drawn according to their order: i.e if castle is drawn before player, player will walk over it
            castle01.Draw(mGame.spriteBatch);
            mPlayer.Draw(gameTime, mGame.spriteBatch);
            mGame.spriteBatch.End();
        }

        #endregion
    }
}
