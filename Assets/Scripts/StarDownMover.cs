using UnityEngine;

public class StarDownMover : MonoBehaviour
{
    private int _starSpeed;
    private int _division;

    private void Start()
    {
        _starSpeed = Random.Range(2, 10);
        _division = Random.Range(1, 20);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _starSpeed * Time.deltaTime / _division);
    }
}