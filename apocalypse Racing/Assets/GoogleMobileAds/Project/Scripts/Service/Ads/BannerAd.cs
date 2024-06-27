using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service.Ads
{
    public class BannerAd : MonoBehaviour
    {
#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        private string _adUnitId = "unused";
#endif

        BannerView _bannerView;

        private void Start ()
        {
            LoadAd();
        }


        public void CreateBannerView()
        {
            Debug.Log("Creating banner view");


            if (_bannerView != null)
            {
                DestroyBannerView();
            }

            _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
        }

        public void LoadAd()
        {
            if (_bannerView == null)
            {
                CreateBannerView();
            }

            var adRequest = new AdRequest();

            Debug.Log("Loading banner ad.");
            _bannerView.LoadAd(adRequest);
        }

        public void DestroyBannerView()
        {
            if (_bannerView != null)
            {
                Debug.Log("Destroying banner view.");
                _bannerView.Destroy();
                _bannerView = null;
            }
        }
    }
}