using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource _mainMenuMusic;

    private void Start()
    {
        _mainMenuMusic = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("music", 0) == 1)
        {
            _mainMenuMusic.Play();
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("music", 0) == 0)
        {
            _mainMenuMusic.Stop();
        }
    }
}