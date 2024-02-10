using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _playText;
    [SerializeField] private TMP_Text _highScore;
    private AudioSource _clickSound;

    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();

        if (PlayerPrefs.GetString("language") == "ru")
        {
            _playText.text = "играть";
            _highScore.text = "лучший результат:";
        }
        else if (PlayerPrefs.GetString("language") == "en")
        {
            _playText.text = "play";
            _highScore.text = "best score:";
        }
    }
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            _clickSound.Play();
        }
        SceneManager.LoadScene("Game");
    }
}