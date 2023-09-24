using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Content
{

    /*This class is the blocks that fall down towards the screen. It should contain the logic falling, rotating, stopping, and colliding with other blocks
     */
    internal class TetrisBlock : Content
    {
        private Microsoft.Xna.Framework.Vector2 _myPosition;
        private Sprite _mySprite;
        private bool _locked;
        private float _fallSpeed = 1;
        TetrisBlock(Sprite s) {
            _mySprite = s;
        }
        new public enum ContentType {
            SQUARE,
            L,
            REVERSE_L,
            Z,
            REVERSE_Z,
            LINE,
            T
        }

        void Fall() { 
            _myPosition = new Microsoft.Xna.Framework.Vector2(_myPosition.X,_myPosition.Y - _fallSpeed);
        }
        void Move() {
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                _myPosition.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                _myPosition.X += 1;
            }
        }
        void Stop() { }
        void Collision() { }
        void Rotate() { }
    }
}
