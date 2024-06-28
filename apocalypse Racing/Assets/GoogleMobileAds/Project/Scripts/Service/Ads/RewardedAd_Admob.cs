using GoogleMobileAds.Api;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Service.Ads
{
    public class RewardedAd_Admob : MonoBehaviour, IRewardedAd
    {
        public bool isReady { get;  set; } = false;
        public Action onReady { get; set; }

#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        private string _adUnitId = "unused";
#endif

        private RewardedAd _rewardedAd;

        //public Action onReady => throw new NotImplementedException();

        private void Start()
        {

            LoadRewardedAd();

        }


        public void LoadRewardedAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            Debug.Log("Loading the rewarded ad.");

            var adRequest = new AdRequest();

            RewardedAd.Load(_adUnitId, adRequest,
                (RewardedAd ad, LoadAdError error) =>
                {

                    if (error != null || ad == null)
                    {
                        Debug.LogError("Rewarded ad failed to load an ad " +
                                       "with error : " + error);
                        return;
                    }

                    Debug.Log("Rewarded ad loaded with response : "
                              + ad.GetResponseInfo());

                    _rewardedAd = ad;

                    isReady = true;
                    onReady?.Invoke();
                });
        }

        public void ShowRewardedAd()
        {
            
        }

        public void ShowRewarded(Action onRewardedShown)
        {
            const string rewardMsg = "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
                    onRewardedShown?.Invoke();
                });
            }
        }
    }
}