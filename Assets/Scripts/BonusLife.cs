using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                FindObjectOfType<AudioManager>().BonusTaken();
            }
            if (PlayerPrefs.GetString("Health") == "need") {
                collision.GetComponent<PlayerController>().GetBonusLife();
            }
            Destroy(gameObject);
        }
    }
}