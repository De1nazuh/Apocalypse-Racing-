using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameStateChanger
    {

        private GameStateBase _currentGameState;

     public void ChangeState(GameStateBase gamestate)
        {
            _currentGameState?.Exit();

            _currentGameState = gamestate;
            _currentGameState.Enter();
        }
    }
}
