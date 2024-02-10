using UnityEngine;

public class SunDumpEnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject _dumpBullet;
    private int _health;
    private Transform player;
    private float _timeBefRestart;

    [SerializeField] private GameObject _partialEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Skin").transform;
        _health = 5;
        _timeBefRestart = Random.Range(1, 3);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            FindObjectOfType<Score>().AdjustMltiplier();
            FindObjectOfType<AudioManager>().SlimeEnemyDead();
            Destroy(gameObject);
        }

        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }

        _timeBefRestart -= Time.deltaTime;

        if (_timeBefRestart <= 0) {
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.5f;
            GameObject _singleBullet = Instantiate(_dumpBullet, newPosition, Quaternion.identity);
            Destroy(_singleBullet, 3f);
            _timeBefRestart = Random.Range(1, 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().InsaneDeath();
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        _health -= 1;
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