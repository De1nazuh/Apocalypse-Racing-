using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
namespace Game
{
    public class MainMenu_GameState : GameStateBase
    {
        [Inject] private GameObject _mainMenuPrefab;
        [Inject] private AudioService _audioService;

        public override void Enter()
        {
            InjectService.Inject(this);

            SceneManager.LoadSceneAsync("MainMenu").completed += (_) =>
                {
                    Object.Instantiate(_mainMenuPrefab);
                    _audioService.PlayAudio("Back");
                };
        }
    }
}