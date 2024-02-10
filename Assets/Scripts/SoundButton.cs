using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _soundText;
    private AudioSource _clickSound;

    [DllImport("__Internal")]
    private static extern void Show();

    public void Start()
    {
        _clickSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 0 && PlayerPrefs.GetString("language") == "ru")
        {
            _soundText.text = "звуки: выкл";
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 0 && PlayerPrefs.GetString("language") == "en")
        {
            _soundText.text = "sounds: off";
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 1 && PlayerPrefs.GetString("language") == "ru")
        {
            _soundText.text = "звуки: вкл";
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 1 && PlayerPrefs.GetString("language") == "en")
        {
            _soundText.text = "sounds: on";
        }
    }

    public void ChangeSoundState()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 0 && PlayerPrefs.GetString("language") == "ru")
        {
            _soundText.text = "звуки: вкл";
            _clickSound.Play();
            PlayerPrefs.SetInt("sounds", 1);
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 0 && PlayerPrefs.GetString("language") == "en")
        {
            _soundText.text = "sounds: on";
            _clickSound.Play();
            PlayerPrefs.SetInt("sounds", 1);
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 1 && PlayerPrefs.GetString("language") == "ru")
        {
            _soundText.text = "звуки: выкл";
            PlayerPrefs.SetInt("sounds", 0);
        }
        else if (PlayerPrefs.GetInt("sounds", 0) == 1 && PlayerPrefs.GetString("language") == "en")
        {
            _soundText.text = "sounds: off";
            PlayerPrefs.SetInt("sounds", 0);
        }
        Show();
    }
}