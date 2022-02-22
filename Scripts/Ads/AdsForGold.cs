using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

public class AdsForGold : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject _startWatchingButton;

    private readonly string _gameId = "4626021";
    private readonly string _myPlacementId = "rewaredVideo";
    private readonly bool _testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        _startWatchingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(_myPlacementId);
            _startWatchingButton.SetActive(false);
        });
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Вам начисленно 100 монеток!");
        }
        else if (showResult == ShowResult.Skipped)
        {

        }
        else if (showResult == ShowResult.Failed)
        {
               
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _myPlacementId)
        {
            _startWatchingButton.SetActive(true);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
}