using UnityEngine.Advertisements;
using UnityEngine;
using System.Collections;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool isTestMode = true;

    private string gameID = "4196807";

    private string video = "Interstitial_Andrroid";
    private string rewardedVideo = "Rewarded_Android";
    private string banner = "Banner_Android";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, isTestMode);

        #region Banner

        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        #endregion
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisment not ready!");
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(banner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
    }
}

