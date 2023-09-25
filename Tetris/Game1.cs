using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Screens;
using Tetris.Content.StateMachine.GameStates;

namespace Tetris
{
    public class Game1 : Game
    {
        Texture2D overworldBlueTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ScreenManager _screenManager;
        public static ContentManager contentManager;
        public static GraphicsDeviceManager graphicsDevice;

        public static readonly Game1 game1 = new Game1();
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            graphicsDevice = _graphics;
            contentManager = Content;
            Components.Add(_screenManager);
        }

        static Game1() { }

        public static Game1 GAME {
            get { return game1; }
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
            GameManager.GM.SetState(new StartMenuState());
            //LoadDemoTown();
        }

        protected override void LoadContent() {


            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            overworldBlueTexture = Content.Load<Texture2D>("border");
        }

        protected override void Update(GameTime gameTime) {
            // TODO: Add your update logic here
            //should run the update for all the active game objects in the correct state machine state
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }

        public void LoadGameScreen(Screen s) {
            _screenManager.LoadScreen(s, new FadeTransition(graphicsDevice.GraphicsDevice, Color.Black));
        }
    }
}