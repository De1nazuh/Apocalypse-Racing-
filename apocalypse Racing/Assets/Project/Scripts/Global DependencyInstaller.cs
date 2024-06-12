using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GlobalDependencyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _mainMenuPrefab;
        [SerializeField] private AudioService _audioService;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().FromInstance(_mainMenuPrefab);
            Container.Bind<AudioService>().FromInstance(_audioService);
        }

    }
}