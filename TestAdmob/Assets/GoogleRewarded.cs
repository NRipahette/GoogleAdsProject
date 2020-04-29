using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class GoogleRewarded : MonoBehaviour {



    private RewardedAd rewardedAdDefault;
    Button myButtonDefault;
    GameObject rewardText;
    Game myGame;
    void Start()
    {
        myButtonDefault = GameObject.Find("Button").GetComponent<Button>();
        myButtonDefault.interactable = false;
        rewardText = GameObject.Find("TextReward");
        rewardText.gameObject.SetActive(false);
        myGame = GameObject.Find("GameManager").GetComponent<Game>();
        if (myButtonDefault) myButtonDefault.onClick.AddListener(UserChoseToWatchAd);

        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAdDefault = CreateAndLoadRewardedAd(adUnitId);
    }

    public RewardedAd CreateAndLoadRewardedAd(string adUnitId)
    {

        RewardedAd rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);

        return rewardedAd;
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        myButtonDefault.interactable = true;
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        rewardText.gameObject.SetActive(true);
        myGame.upgradeClick();
        
    }

    private void UserChoseToWatchAd()
    {
        if (this.rewardedAdDefault.IsLoaded())
        {
            this.rewardedAdDefault.Show();
        }
    }
}
