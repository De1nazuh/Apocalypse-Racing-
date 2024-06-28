using Game;
using GoogleMobileAds.Api;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStart : MonoBehaviour
    {


        
        private GameStateChanger _gameStateChanger = new();
        [Inject] private IRewardedAd _rewardedAd;
        

        //начало игры
        private void Start()
        {
            InjectService.Inject(this);

            DontDestroyOnLoad(gameObject);

                 // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(initStatus => { });

            if (_rewardedAd.isReady == true)
            {
                _rewardedAd.ShowRewarded(OnRewardedWatched);
            }
            else
            {
                _rewardedAd.onReady += () =>
                {
                    _rewardedAd.ShowRewarded(OnRewardedWatched);
                };
            }



        }

        private void OnRewardedWatched()
        {
            _gameStateChanger.ChangeState(new MainMenu_GameState());
        }
    }
}