using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class GamePlay_GameState : GameStateBase
    {
        [Inject] private UIFactory _uIFactory;

        public override void Enter()
        {
            InjectService.Inject(this);
            SceneManager.LoadSceneAsync("GamePlay").completed += (_) =>
            {
                GamePlayUI GamePlay_UI_Copy = _uIFactory.GetUI<GamePlayUI>() as GamePlayUI;
                GamePlay_UI_Copy.MenuButton.onClick.AddListener(GoToMainMenu);

            };
        }
        private void GoToMainMenu()
        {
            gameStateChanger.ChangeState(new MainMenu_GameState());
        }
    }

}