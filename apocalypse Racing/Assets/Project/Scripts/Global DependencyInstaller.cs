using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.UI;
using SO;

namespace Game
{
    public class GlobalDependencyInstaller : MonoInstaller
    {
        [SerializeField] private UIFactory _uIFactory;
        [SerializeField] private AudioService _audioService;
        [SerializeField] private CarScin _CarScin;

        public override void InstallBindings()
        {
            Container.Bind<UIFactory>().FromInstance(_uIFactory);
            Container.Bind<AudioService>().FromInstance(_audioService);
            Container.Bind<CarScin>().FromInstance(_CarScin);
        }

    }
}