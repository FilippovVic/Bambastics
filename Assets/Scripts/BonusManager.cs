using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject _armorBonus;
    [SerializeField] private GameObject _healthBonus;
    [SerializeField] private GameObject _2xBonus;
    [SerializeField] private float[] _spawnPoints;

    private float _timeBeforeArmorSpawn;
    private float _timeBeforeHealthSpawn;
    private float _timeBefore2xBonus;

    private bool _need = false;

    private void Start()
    {
        _timeBeforeArmorSpawn = Random.Range(30, 40);
        _timeBefore2xBonus = Random.Range(30, 50);
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("Health") == "need" && _need == false)
        {
            _timeBeforeHealthSpawn = Random.Range(20, 60);
            _need = true;
        }

        _timeBefore2xBonus -= Time.deltaTime;
        _timeBeforeArmorSpawn -= Time.deltaTime;
        if (_timeBeforeHealthSpawn > 0 && _need == true && FindObjectOfType<PlayerController>()._health != 3)
        {
            _timeBeforeHealthSpawn -= Time.deltaTime;
        }

        if (_timeBeforeArmorSpawn <= 0)
        {
            Instantiate(_armorBonus, new Vector2(_spawnPoints[Random.Range(0, _spawnPoints.Length)], transform.position.y), Quaternion.identity);
            _timeBeforeArmorSpawn = Random.Range(30, 100);
        }

        if (_timeBeforeHealthSpawn < 0 && _need == true && FindObjectOfType<PlayerController>()._health != 3)
        {
            Instantiate(_healthBonus, new Vector2(_spawnPoints[Random.Range(0, _spawnPoints.Length)], transform.position.y), Quaternion.identity);
            _need = false;
        }

        if (_timeBefore2xBonus < 0)
        {
            Instantiate(_2xBonus, new Vector2(_spawnPoints[Random.Range(0, _spawnPoints.Length)], transform.position.y), Quaternion.identity);
            _timeBefore2xBonus = Random.Range(25, 100);
        }
    }
}