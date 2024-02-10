using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _musicText;
    private AudioSource _clickSound;

    [DllImport("__Internal")]
    private static extern void Show();

    [DllImport("__Internal")]
    private static extern string GetLang();

    public string CurrentLanguage;

    private void Awake()
    {
        CurrentLanguage = GetLang();
        PlayerPrefs.SetString("language", CurrentLanguage);
    }

    private void Start()
    {
        CurrentLanguage = GetLang();
        PlayerPrefs.SetString("language", CurrentLanguage);
        _clickSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("music", 0) == 0 && PlayerPrefs.GetString("language") == "ru")
        {
            _musicText.text = "музыка: выкл";
        }
        else if (PlayerPrefs.GetInt("music", 0) == 0 && PlayerPrefs.GetString("language") == "en")
        {
            _musicText.text = "music: off";
        }
        else if (PlayerPrefs.GetInt("music", 0) == 1 && PlayerPrefs.GetString("language") == "ru")
        {
            _musicText.text = "музыка: вкл";
        }
        else if (PlayerPrefs.GetInt("music", 0) == 1 && PlayerPrefs.GetString("language") == "en")
        {
            _musicText.text = "music: on";
        }
    }

    public void ChangeMusicState()
    {
        if (PlayerPrefs.GetInt("music", 0) == 0 && PlayerPrefs.GetString("language") == "ru")
        {
            _musicText.text = "музыка: вкл";
            if (PlayerPrefs.GetInt("sounds", 0) == 1) {
                _clickSound.Play();
            }
            PlayerPrefs.SetInt("music", 1);
        }
        else if (PlayerPrefs.GetInt("music", 0) == 0 && PlayerPrefs.GetString("language") == "en")
        {
            _musicText.text = "music: on";
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _clickSound.Play();
            }
            PlayerPrefs.SetInt("music", 1);
        }
        else if (PlayerPrefs.GetInt("music", 0) == 1 && PlayerPrefs.GetString("language") == "ru")
        {
            _musicText.text = "музыка: выкл";
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _clickSound.Play();
            }
            PlayerPrefs.SetInt("music", 0);
        }
        else if (PlayerPrefs.GetInt("music", 0) == 1 && PlayerPrefs.GetString("language") == "en")
        {
            _musicText.text = "music: off";
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _clickSound.Play();
            }
            PlayerPrefs.SetInt("music", 0);
        }
        Show();
    }
}