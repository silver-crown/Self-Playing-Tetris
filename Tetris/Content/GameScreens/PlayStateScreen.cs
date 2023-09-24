using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace Tetris.Content.GameScreens
{
    internal class PlayStateScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        private SpriteBatch _spriteBatch;
        Texture2D overworldBlueTexture;
        private Vector2 _position = new Vector2(50, 50);
        public PlayStateScreen(Game1 game) : base(game) { }

        public override void LoadContent() {
            overworldBlueTexture = Game1.contentManager.Load<Texture2D>("border");
            _spriteBatch = new SpriteBatch(Game1.graphicsDevice.GraphicsDevice);
        }

        public override void Update(GameTime gameTime) {
        }

        public override void Draw(GameTime gameTime) {
            _spriteBatch.Begin();

            _spriteBatch.Draw(overworldBlueTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.End();
        }
    }
}
