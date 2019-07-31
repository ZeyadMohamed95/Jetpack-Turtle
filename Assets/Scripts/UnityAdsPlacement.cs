using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;
public class UnityAdsPlacement : MonoBehaviour
{
    public static UnityAdsPlacement instance;
    public string placementId = "video";
    public string bannerPlacement = "BannerAd";
    public string store_id = "3089752";
    

    void Awake()
    {
        if (instance !=null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ShowAd()
    {
        StartCoroutine(ShowAdWhenReady());
        Monetization.Initialize(store_id, true);
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }
    public void ShowBanner()
    {
        StartCoroutine(ShowBannerWhenReady());
        Monetization.Initialize(store_id, true);
    }
    IEnumerator ShowBannerWhenReady()
    {
        while (!Monetization.IsReady(bannerPlacement))
        {
            yield return new WaitForSeconds(0.5f);
        }
        ShowAdPlacementContent adv = null;
        adv = Monetization.GetPlacementContent(bannerPlacement) as ShowAdPlacementContent;

        if (adv != null)
        {
            adv.Show();
        }
    }
    
}
