using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MainMenu_GameState : GameStateBase
    {
        public override void Enter()
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}