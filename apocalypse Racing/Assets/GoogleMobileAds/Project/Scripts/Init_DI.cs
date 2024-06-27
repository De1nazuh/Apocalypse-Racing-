using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game{ 
public class Init_DI : MonoInstaller
{
        [SerializeField] private AudioService _audioService;

        public override void InstallBindings()
        {
            Container.Bind<AudioService>().FromInstance(_audioService);
        }
    }
}