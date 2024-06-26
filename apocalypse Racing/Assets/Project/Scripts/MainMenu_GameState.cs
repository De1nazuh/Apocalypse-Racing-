using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Game.UI;

namespace Game
{
    public class MainMenu_GameState : GameStateBase
    {
        [Inject] private UIFactory _uIFactory;
        [Inject] private AudioService _audioService;
        [Inject] private Test _CarScin;

        public override void Enter()
        {
            InjectService.Inject(this);

            SceneManager.LoadSceneAsync("MainMenu").completed += (_) =>
                {
                    MainMenuUI mainMenu_UI_Copy = _uIFactory.GetUI<MainMenuUI>() as MainMenuUI;
                    mainMenu_UI_Copy.playButton.onClick.AddListener(GoToGamePlay);

                    _audioService.PlayAudio("Back");
                };
        }
        private void GoToGamePlay()
        {
            gameStateChanger.ChangeState(new GamePlay_GameState());
        }
    }
}