using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IRewardedAd
    {
        public bool isReady { get; }
        public Action onReady { get; set; }

        public void ShowRewarded(Action onRewardedShown);

    }
}
