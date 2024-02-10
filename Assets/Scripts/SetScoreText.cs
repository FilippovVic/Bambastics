using TMPro;
using UnityEngine;

public class SetScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private Score _script;
    private void Start()
    {
        _script = FindObjectOfType<Score>();
    }

    private void Update()
    {
        _scoreText.text = _script.GetScore().ToString();
    }
}
