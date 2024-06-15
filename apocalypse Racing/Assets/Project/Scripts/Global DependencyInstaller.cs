using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.UI;

namespace Game
{
    public class GlobalDependencyInstaller : MonoInstaller
    {
        [SerializeField] private UIFactory _uIFactory;
        [SerializeField] private AudioService _audioService;

        public override void InstallBindings()
        {
            Container.Bind<UIFactory>().FromInstance(_uIFactory);
            Container.Bind<AudioService>().FromInstance(_audioService);
        }

    }
}