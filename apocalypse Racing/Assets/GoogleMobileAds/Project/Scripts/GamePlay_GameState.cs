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
                GamePlay_UI_Copy.PauseButton.onClick.AddListener(GoToPauseMenu);

            };
        }

        private void GoToPauseMenu()
        {
            PauseUI Pause_UI_Copy = _uIFactory.GetUI<PauseUI>() as PauseUI;
            Pause_UI_Copy.MainMenuButton.onClick.AddListener(GoToMainMenu);
            Pause_UI_Copy.Continue.onClick.AddListener(() =>
            {
                Pause_UI_Copy.gameObject.SetActive(false);
            });
        }

        private void GoToMainMenu()
        {
            gameStateChanger.ChangeState(new MainMenu_GameState());
        }

        private void GoToWinMenu()
        {
            WinUI WinUI_UI_Copy = _uIFactory.GetUI<WinUI>() as WinUI;
            WinUI_UI_Copy.MainMenuButton.onClick.AddListener(GoToMainMenu);
            
        }


    }

}