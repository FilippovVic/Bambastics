using System.Runtime.InteropServices;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _panelState;
    private AudioSource _clickSound;
    [SerializeField] private GameObject _backMusic;

    [DllImport("__Internal")]
    private static extern void Show();

    private void Start()
    {
        _clickSound = GetComponent<AudioSource>();
    }

    public void ActivatePanel()
    {
        if (!_panelState) {
            if (PlayerPrefs.GetInt("sounds", 0) == 1) {
                _clickSound.Play();
            }
            _pausePanel.SetActive(true);

            if (PlayerPrefs.GetInt("music", 0) == 1) {
                _backMusic.GetComponent<BackgroundMusic>().PauseMusic();
            }
            _panelState = true;
            Time.timeScale = 0.0f;
            Show();
        }
        else
        {
            if (PlayerPrefs.GetInt("music", 0) == 1)
            {
                _backMusic.GetComponent<BackgroundMusic>().ContinuePlayMusic();
            }
            _pausePanel.SetActive(false);
            _panelState = false;
            Time.timeScale = 1.0f;
        }
    }
}