using UnityEngine.UI;
using UnityEngine;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private AudioClip _buttonPress;

    private void Update()
    {
        if (_player.PlayerDied == true)
        {
            _nextWaveButton.interactable = false;
        }
    }

    private void OnEnable()
    {
        _spawner.AllEnemiesSpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesSpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}