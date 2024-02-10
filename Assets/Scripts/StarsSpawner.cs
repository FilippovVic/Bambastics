using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _starsPrefs;
    [SerializeField] private float[] _spawnPoints;
    private float _timeBeforeStart;

    private void Start()
    {
        _timeBeforeStart = Random.Range(1, 20) / 5;
    }
    private void Update()
    {
        if (_timeBeforeStart < 0) {
            Instantiate(_starsPrefs[Random.Range(0, _starsPrefs.Length)], new Vector2(_spawnPoints[Random.Range(0, _spawnPoints.Length)], transform.position.y), Quaternion.identity);
            _timeBeforeStart = Random.Range(1, 20) / 5;
        }
        else
        {
            _timeBeforeStart -= Time.deltaTime;
        }
    }
}