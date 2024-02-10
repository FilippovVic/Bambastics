using UnityEngine;

public class SlimeEnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject _partialEffect;
    private int _damage;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Skin").transform;
        _damage = 1;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().GetDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        try
        {
            GameObject _dieEffect = Instantiate(_partialEffect, transform.position, Quaternion.identity);
            Destroy(_dieEffect, 0.1f);
        }
        catch { }
    }
}