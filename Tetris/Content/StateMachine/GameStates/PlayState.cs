using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Content.StateMachine.GameStates
{

    //This state should dictate everyhing happening when the player is playing a game of tetris, it should also switch to relevant states
    internal class PlayState : State
    {
        public override IEnumerator End() {
            return base.End();
        }

        public override IEnumerator Execute() {
            return base.Execute();
        }

        public override IEnumerator Pause() {
            return base.Pause();
        }

        public override IEnumerator Resume() {
            return base.Resume();
        }

        public override IEnumerator Start() {
            return base.Start();
        }
    }
}
