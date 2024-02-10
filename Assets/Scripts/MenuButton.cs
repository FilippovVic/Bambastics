using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private AudioSource _clickSound;

    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();
    }
    public void LoadMenu()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            StartCoroutine(PlaySoundAndWait());
        } else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
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
        SceneManager.LoadScene("MainMenu");
    }
}