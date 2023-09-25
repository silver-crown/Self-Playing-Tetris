using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Content.GameScreens;

namespace Tetris.Content.StateMachine.GameStates
{

    //OBSOLETE CLASS! functionality is fulfilled by PlayState's Pause/Resume methods
    internal class PauseMenuState : State
    {

        ~PauseMenuState() { 
        }
        public override IEnumerator Start() {
            yield return Execute().MoveNext();
        }
        public override IEnumerator End() {
            GameManager.GM.KillStateThread();
            yield break;
        }
        public override IEnumerator Execute() {
            //nothing much happens here, the purpose of this whole class is for PlayState to stop what it's doing
            while (true) {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
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
    }
}
