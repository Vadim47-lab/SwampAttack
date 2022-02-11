using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _delay;
    private int _spawned;

    public event UnityAction AllEnemiesSpawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        StartCoroutine(SpawnEnemy());

        if (_currentWave.Count <= _spawned)
        {
            if(_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemiesSpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        _delay += Time.deltaTime;

        if (_delay > _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _delay = 0;
        }

       yield return waitForSeconds;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    } 

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}