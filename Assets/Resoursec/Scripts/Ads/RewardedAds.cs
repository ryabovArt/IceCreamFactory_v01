using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private BoxActions box;

    [SerializeField] private bool isTestMode = true;
    [SerializeField] private Button adsButton;

    private string gameID = "4196807";

    private string rewardedVideo = "Rewarded_Android";

    private void Start()
    {
        adsButton = GetComponent<Button>();
        adsButton.interactable = Advertisement.IsReady(rewardedVideo);

        if (adsButton)
            adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, isTestMode);

        #region Banner

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        #endregion
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideo);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardedVideo)
        {
            adsButton.interactable = true;
        }
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
        if (GameManager.staticLevel >= 0 && GameManager.staticLevel <= 3)
        {
            box = GameObject.FindGameObjectWithTag("Box").GetComponent<BoxActions>();
            box.PlayBoxAnimation();
        }
        if (GameManager.staticLevel == 4)
        {
            box = GameObject.FindGameObjectWithTag("Box").GetComponent<BoxActions>();
            box.PlayBoxAnimation2();
        }
    }
}
