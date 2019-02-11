
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using QAds;

public class AdManager : MonoBehaviour {

	public void Start()
	{
		QuickAds.instance.ShowBanner();
		QuickAds.instance.ShowInterstitialAd();
	}

	public void ShowDefaultAd()
    {
        #if UNITY_EDITOR
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        Advertisement.Show();
        #endif
    }

}
