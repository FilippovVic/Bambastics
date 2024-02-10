using UnityEngine;

public class x2BonusBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().BulletSpawnTime();
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                FindObjectOfType<AudioManager>().BonusTaken();
            }
            Destroy(gameObject);
        }
    }
}