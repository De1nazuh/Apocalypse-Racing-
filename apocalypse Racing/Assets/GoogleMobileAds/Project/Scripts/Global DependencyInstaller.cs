using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.UI;
using SO;
using GoogleMobileAds.Api;
using Service.Ads;
using Interfaces;

namespace Game
{
    public class GlobalDependencyInstaller : MonoInstaller
    {
        [SerializeField] private UIFactory _uIFactory;
        [SerializeField] private AudioService _audioService;

        [Header("Ads")]
        [SerializeField] private BannerAd _bannerAD;
        [SerializeField] private RewardedAd_Admob _rewardedAd;

        [Header("Lists")]
        [SerializeField] private CarScin _carList;

        public override void InstallBindings()
        {

          //контейнер //в каком виде                 \\какой обьект
            Container.Bind<UIFactory>().FromInstance(_uIFactory);
            Container.Bind<AudioService>().FromInstance(_audioService);
            

            
            Container.Bind<IRewardedAd>().FromInstance(_rewardedAd);

            Container.Bind<CarScin>().FromInstance(_carList);
            Container.Bind<ICarSaveManager>().FromInstance(_carList);

        }

    }
}