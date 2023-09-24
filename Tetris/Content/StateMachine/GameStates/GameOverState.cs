using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Content.StateMachine.GameStates
{

    /*Should handle logic happening during a game over.
     * Save the player's score (either locally or online via a cloud service)
     * should either start a new PlayState or send the player back go StartMenuState
    */
    internal class GameOverState : State
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
