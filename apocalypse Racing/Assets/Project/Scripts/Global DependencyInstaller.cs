using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GlobalDependencyInstaller : MonoInstaller
{
    [SerializeField] private GameObject _mainMenuPrefab;
    [SerializeField] private Sprite _item;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(_mainMenuPrefab);
        Container.Bind<Sprite>().FromInstance(_item);
    }

}
