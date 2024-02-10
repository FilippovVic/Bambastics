using System.Collections;
using UnityEngine;

public class FastBlueEnemy : MonoBehaviour
{

    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _endSpeed;
    [SerializeField] private float _waitTimeMin;
    [SerializeField] private float _waitTimeMax;
    [SerializeField] private Vector3[] _movePoints;
    [SerializeField] public int _health;
    private bool _ready;
    private Transform _player;

    [SerializeField] private GameObject _partialEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().GetDamage(1);
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        _health -= 1;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            FindObjectOfType<Score>().AdjustMltiplier();
            FindObjectOfType<AudioManager>().SlimeEnemyDead();
            Destroy(gameObject);
        }

        if (_ready &&_player != null)
        {
            Vector3 direction = _player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * _endSpeed * Time.deltaTime);
        }
    }

    private void Start()
    {
        _ready = false;
        _player = GameObject.FindGameObjectWithTag("Skin").transform;
        StartCoroutine(MoveSequence());
    }

    IEnumerator MoveSequence()
    {
        while (true)
        {
            Vector3 destination = _movePoints[Random.Range(0, _movePoints.Length)];
            yield return StartCoroutine(MoveToDestination(destination));
            yield return new WaitForSeconds(Random.Range(_waitTimeMin, _waitTimeMax));
            _ready = true;
            break;
        }
    }

    IEnumerator MoveToDestination(Vector3 destination)
    {
        while (transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, _normalSpeed * Time.deltaTime); ;
            yield return null;
        }
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObject _dieEffect = Instantiate(_partialEffect, transform.position, Quaternion.identity);
        Destroy(_dieEffect, 0.1f);
    }
}