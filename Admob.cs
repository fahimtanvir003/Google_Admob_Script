using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    public Text rewardedText;
    public Text interstitialText;

    string app_ID = "ca-app-pub-8170963119776121~8673693564";

    string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

    string rewarded_ID = "ca-app-pub-3940256099942544/5224354917";

    private InterstitialAd interstitialAD;
    private RewardedAd rewardedAD;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(app_ID);
        this.rewardedAD = new RewardedAd(rewarded_ID);

        RequestInterstitial();
        RequestRewardedAd();
    }

    private void RequestInterstitial()
    {
       
        interstitialText.text = "Requesting Interstitial";
        // Initialize an InterstitialAd.
        this.interstitialAD = new InterstitialAd(interstitial_ID);

        // Called when an ad request has successfully loaded.
        this.interstitialAD.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitialAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitialAD.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitialAD.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitialAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitialAD.LoadAd(request);

    }

    private void RequestRewardedAd()
    {
        rewardedText.text = "Requesting Rewarded";
        this.rewardedAD = new RewardedAd(rewarded_ID);

        // Called when an ad request has successfully loaded.
        this.rewardedAD.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAD.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAD.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAD.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAD.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAD.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAD.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitialAD.IsLoaded())
        {
            interstitialText.text = "Showing Interstitial";
            this.interstitialAD.Show();
        }
    }

    public void ShowRewardedVideoAd()
    {
        rewardedText.text = "Showing Rewarded Ad";
        if (this.rewardedAD.IsLoaded())
        {
            this.rewardedAD.Show();
        }
    }

    // Interstitial

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLoaded event received");
        interstitialText.text = " Interstitial Ad Loaded";
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
        // + args.Message);
        interstitialText.text = "Interstitial Ad Not Loaded";
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    //Interstitial


    //REWARDED

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdLoaded event received");
        rewardedText.text = "Rewarded Ad Loaded";
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        /* MonoBehaviour.print(
             "HandleRewardedAdFailedToLoad event received with message: "
                              + args.Message);*/
        rewardedText.text = "Rewarded Ad Not Loaded";
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
        /* string type = args.Type;
         double amount = args.Amount;
         MonoBehaviour.print(
             "HandleRewardedAdRewarded event received for "
                         + amount.ToString() + " " + type);*/
        rewardedText.text = "Got Reward Ad Loaded";
    }

    //REWARDED

}
