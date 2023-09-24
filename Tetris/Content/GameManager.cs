using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using MonoGame.Extended.Screens;
using Microsoft.Xna.Framework;

public sealed class GameManager : StateMachine
{

    //non-lazy singleton pattern for the game manager
    private static readonly GameManager gm = new GameManager();
    private Screen _activeScreen;

    static GameManager() {

    }
    private GameManager() {

    }

    public static GameManager GM {
        get {
            return gm;
        }
    }

    public void Start() {
        Debug.WriteLine(" Object is not valid for this category.");
    }
}

