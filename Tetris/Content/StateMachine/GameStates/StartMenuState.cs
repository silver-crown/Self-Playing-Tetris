using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tetris.Content.GameScreens;

namespace Tetris.Content.StateMachine.GameStates
{

    /*This state should dictate everything happening in the start menu of the tetris game.
     * Should jump into PlayState and start a game of tetris
     * Should Quit the game if the player presses quit
     * Should 
     */
    internal class StartMenuState : State
    {
        public override IEnumerator End() {
            GameManager.GM.KillStateThread();
            yield break;
        }

        public override IEnumerator Execute() {
            while (true) {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                    GameManager.GM.SetState(new PlayState());
                    yield return End().MoveNext();
                }
            }
        }

        public override IEnumerator Pause() {
            return base.Pause();
        }

        public override IEnumerator Resume() {
            return base.Resume();
        }

        public override IEnumerator Start() {
            Game1.GAME.LoadGameScreen(new StartMenuScreen(Game1.GAME));
            yield return Execute().MoveNext();
        }
    }
}
