using UnityEngine;

public class DumpBulletMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _initialPlayerPosition;
    private Vector3 _direction;

    private void Start()
    {
        _initialPlayerPosition = FindObjectOfType<PlayerController>().transform.position;
        _direction = (_initialPlayerPosition - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().GetDamage(1);
            Destroy(gameObject);
        }

        if (collision.CompareTag("LeftColl") || collision.CompareTag("RightColl"))
        {
            Destroy(gameObject);
        }
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }
}