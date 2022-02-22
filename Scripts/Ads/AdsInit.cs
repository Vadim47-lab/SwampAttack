using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine;

public class AdsInit : MonoBehaviour
{
    private readonly string _gameId = "4626021";
    private readonly bool _testMode = true;

    private void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("MainBottom"))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.Show("MainBottom");
    }
}
