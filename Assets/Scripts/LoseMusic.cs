using TMPro;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    private AudioSource _loseMusic;
    [SerializeField] private GameObject _backMusic;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _loseText;

    private void Start()
    {
        if (PlayerPrefs.GetInt("music", 0) == 1)
        {
            _loseMusic = GetComponent<AudioSource>();
            _loseMusic.Play();
        }

        if (PlayerPrefs.GetString("language") == "ru") {
            _scoreText.text = "СЧЕТ: " + FindObjectOfType<Score>().GetScore();
            _loseText.text = "игра окончена";
        }
        else if (PlayerPrefs.GetString("language") == "en")
        {
            _scoreText.text = "score: " + FindObjectOfType<Score>().GetScore();
            _loseText.text = "game over";
        }
        Destroy(_backMusic);
    }
}