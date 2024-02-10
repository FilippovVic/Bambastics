using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDownMover : MonoBehaviour
{
    private int _speed;

    private void Start()
    {
        _speed = Random.Range(2, 4);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
}