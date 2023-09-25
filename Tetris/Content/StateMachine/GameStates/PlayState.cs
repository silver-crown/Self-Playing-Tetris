using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tetris.Content.GameScreens;

namespace Tetris.Content.StateMachine.GameStates
{

    //This state should dictate everyhing happening when the player is playing a game of tetris, it should also switch to relevant states
    internal class PlayState : State
    {
        public override IEnumerator End() {
            return base.End();
        }

        //while execute is running, normal game logic should apply (controls, blocks falling etc.)
        public override IEnumerator Execute() {
            //if the player presses the pause button, we should go into Pause, and start a new pause state
            while (true) {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && Keyboard.GetState().IsKeyUp(Keys.Escape)) {
                    yield return Pause().MoveNext();
                }
            }
        }

        public override IEnumerator Pause() {
            //if the pause menu no longer exists, we resume
            while(true) {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && Keyboard.GetState().IsKeyUp(Keys.Escape)) {
                    yield return Resume().MoveNext();
                }
            }
        }

        public override IEnumerator Resume() {
            yield return Execute().MoveNext();
        }

        public override IEnumerator Start() {
            Game1.GAME.LoadGameScreen(new PlayStateScreen(Game1.GAME));
            yield return Execute().MoveNext();
        }
    }
}
