using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private GameObject _shot;

    private void Start()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1) { 
        AudioSource _shotSound = Instantiate(_shot, transform).GetComponent<AudioSource>();
        _shotSound.Play();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SlimeEnemy"))
        {
            FindObjectOfType<AudioManager>().SlimeEnemyDead();
            FindObjectOfType<Score>().AdjustMltiplier();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("DumpEnemy"))
        {
            collision.gameObject.GetComponent<SunDumpEnemyMove>().GetDamage();
            Destroy(gameObject);
        }

        if (collision.CompareTag("PathEnemy"))
        {
            collision.gameObject.GetComponent<PathEnemyMove>().GetDamage();
            Destroy(gameObject);
        }

        if (collision.CompareTag("GunEnemy"))
        {
            collision.gameObject.GetComponent<GunEnemy>().GetDamage();
            Destroy(gameObject);
        }

        if (collision.CompareTag("FastEnemy"))
        {
            collision.gameObject.GetComponent<FastBlueEnemy>().GetDamage();
            Destroy(gameObject);
        }
    }
}