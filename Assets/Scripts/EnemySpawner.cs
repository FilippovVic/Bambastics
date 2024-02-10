using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _interval;

    [SerializeField] private float _lvl1;
    [SerializeField] private float _lvl2;
    [SerializeField] private float _lvl3;
    [SerializeField] private float _lvl4;
    [SerializeField] private float _lvl5;
    [SerializeField] private float _lvl6;
    [SerializeField] private float _lvl7;
    [SerializeField] private float _lvl8;

    [SerializeField] private int _difficultyLevel;

    private float _difficultyTimer;

    private void Start()
    {
        _spawnInterval = 3.5f;
        _interval = 3.5f;
    }

    private void Update()
    {
        _difficultyTimer += Time.deltaTime;

        if (_difficultyTimer < _lvl1)
        {
            _difficultyLevel = 1;
        }
        else if (_difficultyTimer < _lvl2)
        {
            _difficultyLevel = 2;
        }
        else if (_difficultyTimer < _lvl3)
        {
            _difficultyLevel = 4;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 2.65f;
            }
        }
        else if (_difficultyTimer < _lvl4)
        {
            _difficultyLevel = 6;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 2.8f;
            }
        }
        else if (_difficultyTimer < _lvl5)
        {
            _difficultyLevel = 8;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 2.65f;
            }
        }
        else if (_difficultyTimer < _lvl6)
        {
            _difficultyLevel = 10;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 2.7f;
            }
        }
        else if (_difficultyTimer < _lvl7)
        {
            _difficultyLevel = 11;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 3f;
            }
        }
        else if (_difficultyTimer < _lvl8)
        {
            _difficultyLevel = 12;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 3.2f;
            }
        }
        else if (_difficultyTimer > _lvl8)
        {
            _difficultyLevel = 23;
            if (PlayerPrefs.GetInt("Multiplier", 1) == 50)
            {
                _interval = 2.2f;
            }
            else
            {
                _interval = 2.7f;
            }
        }

        _spawnInterval -= Time.deltaTime;

        if (_spawnInterval < 0)
        {
            SpawnEnemy();
            _spawnInterval = _interval;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefabs[Random.Range(0, _difficultyLevel)], transform.position, Quaternion.identity);
    }
}