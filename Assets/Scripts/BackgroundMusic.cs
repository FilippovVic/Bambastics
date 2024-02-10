using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _backgroundMusic;

    private void Start()
    {
        if (PlayerPrefs.GetInt("music", 0) == 1) {
            _backgroundMusic = GetComponent<AudioSource>();
            _backgroundMusic.Play();
        }
    }

    public void PauseMusic()
    {
        _backgroundMusic.Pause();
    }

    public void ContinuePlayMusic()
    {
        _backgroundMusic.Play();
    }
}