using System.Collections;
using System.Collections.Generic;
using System.Threading;

public abstract class StateMachine
{
    Thread stateThread;
    protected State state;
    /// <summary>
    /// Set the state
    /// </summary>
    /// <param name="state"></param>
    public void SetState(State s) {
        state = s;
        stateThread = new Thread(s.Init);
        stateThread.Start();
    }

    public void KillStateThread() {
        stateThread.Interrupt();
        stateThread = null;
    }
    public State GetState(){
        State s = state;
        return s;
    }
}