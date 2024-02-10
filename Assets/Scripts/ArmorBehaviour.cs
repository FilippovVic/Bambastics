using UnityEngine;

public class ArmorBehaviour : MonoBehaviour
{
    private AudioSource _armorSound;
    private float _time;
    private void OnEnable()
    {
        _time = 15;
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            _armorSound = GetComponent<AudioSource>();
            _armorSound.Play();
        }
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -=Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
        if (_time < 0.4 & _time > 0.3)
        {
            if (PlayerPrefs.GetInt("sounds", 0) == 1)
            {
                _armorSound.Play();
            }
        }
    }
}