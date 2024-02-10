using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _armor;
    private float _bulletSpawnTime;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private ParticleSystem _particles;
    private Vector2 _targetPosition;
    private float _shotTimer;
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _brokenHeart;
    [SerializeField] private Sprite _fullHeart;
    public int _health;
    private Animator _animator;
    private AudioSource _damagedSound;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _bonusManager;

    [SerializeField] private GameObject _multiplierX;
    [SerializeField] private GameObject _multiplierNumber;

    private float minX = -2.05f;
    private float maxX = 2.05f;
    private float minY = -5.5f;
    private float maxY = 2.8f;

    private Score _script;

    private float _bonusTime = 18;

    [DllImport("__Internal")]
    private static extern void SetToLeaderBoard(int value);

    private void Start()
    {
        _script = FindObjectOfType<Score>();
        _bulletSpawnTime = 0.45f;
        _health = 3;
        _animator = GetComponent<Animator>();
        _damagedSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_bonusTime > 0 && _bonusTime < 16)
        {
            _bonusTime -= Time.deltaTime;
        }
        else if (_bonusTime < 0)
        {
            _bulletSpawnTime = 0.44f;
            _moveSpeed = 3;
            _bonusTime = 18;
        }

        if (PlayerPrefs.GetInt("Multiplier", 1) == 50 && _bonusTime == 18)
        {
            _bulletSpawnTime = 0.3f;
            _moveSpeed = 3.5f;
        }
        else if (PlayerPrefs.GetInt("Multiplier", 1) != 50 && _bonusTime == 18)
        {
            _bulletSpawnTime = 0.44f;
            _moveSpeed = 3;
        }

        if (_health <= 0)
        {
            if (PlayerPrefs.GetFloat("BestScore", 0) < _script.GetScore())
            {
                Progress.Instance.PlayerInfo._bestScore = _script.GetScore();
                PlayerPrefs.SetFloat("BestScore", _script.GetScore());
                Progress.Instance.Save();
                SetToLeaderBoard((int)_script.GetScore());
            }
            _losePanel.SetActive(true);
            FindObjectOfType<AudioManager>().PlayerDestroyed();

            try
            {
                FindObjectOfType<SlimeEnemyMove>().DoDestroy();
            }
            catch (NullReferenceException) { }
            try
            {
                FindObjectOfType<GunEnemy>().DoDestroy();
            }
            catch (NullReferenceException) { }
            try
            {
                FindObjectOfType<DumpBulletMove>().DoDestroy();
            }
            catch (NullReferenceException) { }
            try
            {
                FindObjectOfType<SunDumpEnemyMove>().DoDestroy();
            }
            catch (NullReferenceException) { }
            try
            {
                FindObjectOfType<PathEnemyMove>().DoDestroy();
            }
            catch (NullReferenceException) { }
            try
            {
                FindObjectOfType<FastBlueEnemy>().DoDestroy();
            }
            catch (NullReferenceException) { }

            Destroy(_multiplierX);
            Destroy(_multiplierNumber);
            Destroy(_score);
            Destroy(_enemySpawner);
            Destroy(_pauseButton);
            Destroy(_bonusManager);
            Destroy(gameObject);
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0.0f)
        {
            _particles.Play();
            _animator.SetTrigger("Moved");
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minX, maxX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minY, maxY);
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            if (Time.time > _shotTimer)
            {
                _shotTimer = Time.time + _bulletSpawnTime;
                Vector3 newPosition = transform.position;
                newPosition.y += 1.5f;
                GameObject _singleBullet = Instantiate(_bullet, newPosition, Quaternion.identity);
                Destroy(_singleBullet, 2f);
            }
        }
        else
        {
            _particles.Stop();
        }

        if (_health <= 2 && _health > 0)
        {
            PlayerPrefs.SetString("Health", "need");
        }

        if (_health == 3)
        {
            PlayerPrefs.SetString("Health", "noNeed");
        }
    }

    public void ActivateArmor()
    {
        _armor.SetActive(true);
    }

    public void GetDamage(int damage)
    {
        if (_armor.activeSelf == true)
        {
            _armor.SetActive(false);
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _damagedSound.Play();
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _damagedSound.Play();
            }
            FindObjectOfType<Score>().ResetMultiplier();
            if (_health > 0) {
                _health -= damage;
                _animator.SetTrigger("Hited");
                _hearts[_health].sprite = _brokenHeart;
            }
        }
    }

    public void GetBonusLife()
    {
        _hearts[_health].sprite = _fullHeart;
        _health += 1;
    }

    public void InsaneDeath()
    {
        _hearts[2].sprite = _brokenHeart;
        _hearts[1].sprite = _brokenHeart;
        _hearts[0].sprite = _brokenHeart;
        _health = 0;
    }

    public void BulletSpawnTime()
    {
        _bulletSpawnTime = 0.22f;
        _moveSpeed = 3.75f;
        _bonusTime = 15f;
    }
}