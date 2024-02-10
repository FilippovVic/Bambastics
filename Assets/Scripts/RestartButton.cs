using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private AudioSource _clickSound;

    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();
    }
    public void RestartGame()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            StartCoroutine(PlaySoundAndWait());
        } else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Game");
        }
    }

    private IEnumerator PlaySoundAndWait()
    {
        _clickSound.Play();
        while (_clickSound.isPlaying)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}