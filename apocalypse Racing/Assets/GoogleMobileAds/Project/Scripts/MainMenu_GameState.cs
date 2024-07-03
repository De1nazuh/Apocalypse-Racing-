using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Game.UI;
using SO;
using UI;

namespace Game
{
    public class MainMenu_GameState : GameStateBase
    {
        [Inject] private UIFactory _uIFactory;
        [Inject] private AudioService _audioService;
        [Inject] private CarScin _CarScin;

        private MainMenuUI _mainMenuUI;
        private ShopMenu _shopMenu;

        public override void Enter()
        {
            InjectService.Inject(this);

            SceneManager.LoadSceneAsync("MainMenu").completed += (_) =>
                {
                    _mainMenuUI = _uIFactory.GetUI<MainMenuUI>() as MainMenuUI;
                    _shopMenu = _uIFactory.GetUI<ShopMenu>() as ShopMenu;

                    _mainMenuUI.playButton.onClick.AddListener(GoToGamePlay);
                    _mainMenuUI.ShopButton.onClick.AddListener(OpenShop);

                    _shopMenu.BackButton.onClick.AddListener(OpenMainMenu);

                    OpenMainMenu();

                    _audioService.PlayAudio("Back");
                };
        }
        private void GoToGamePlay()
        {
            gameStateChanger.ChangeState(new GamePlay_GameState());
        }

        private void OpenShop()
        {
            _mainMenuUI.gameObject.SetActive(false);
            _shopMenu.gameObject.SetActive(true);
        }
        private void OpenMainMenu()
        {
            _mainMenuUI.gameObject.SetActive(true);
            _shopMenu.gameObject.SetActive(false);
        }
    }
}