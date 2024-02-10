using UnityEngine;

public class ArmorBonusBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerController>().ActivateArmor();
            Destroy(gameObject);
        }
    }
}