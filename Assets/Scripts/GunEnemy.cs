using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isReturn;
    private Vector3[] _newPosition;
    private int _currentPos;
    [SerializeField] private int _health;

    private float _timeBefRestart;

    [SerializeField] private GameObject _dumpBullet;

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

    private void Start()
    {
        _newPosition = NewPositionByPath(_pathPoints);
        _timeBefRestart = Random.Range(1, 3);
    }

    private void Update()
    {
        _timeBefRestart -= Time.deltaTime;

        if (_timeBefRestart <= 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.5f;
            GameObject _singleBullet = Instantiate(_dumpBullet, newPosition, Quaternion.identity);
            Destroy(_singleBullet, 3f);
            _timeBefRestart = Random.Range(1, 3);
        }

        if (_health <= 0)
        {
            FindObjectOfType<Score>().AdjustMltiplier();
            FindObjectOfType<AudioManager>().SlimeEnemyDead();
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, _newPosition[_currentPos], _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _newPosition[_currentPos]) < 0.2f)
        {
            _currentPos++;
            if (_isReturn && Vector3.Distance(transform.position, _newPosition[_newPosition.Length - 1]) < 0.3f)
            {
                _currentPos = 0;
            }
        }
    }

    Vector3[] NewPositionByPath(Transform[] _pathPos)
    {
        Vector3[] pathPositions = new Vector3[_pathPos.Length];
        for (int i = 0; i < _pathPoints.Length; i++)
        {
            pathPositions[i] = _pathPos[i].position;
        }
        return pathPositions;
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