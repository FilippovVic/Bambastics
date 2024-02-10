using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject _deadSound;
    private AudioSource _soundDead;

    [SerializeField] GameObject _destroySound;
    private AudioSource _soundDestroy;

    [SerializeField] GameObject _bonusSound;
    private AudioSource _soundBonus;

    private void Start()
    {
        _soundDead = Instantiate(_deadSound, transform).GetComponent<AudioSource>();
        _soundDestroy = Instantiate(_destroySound, transform).GetComponent<AudioSource>();
        _soundBonus = Instantiate(_bonusSound, transform).GetComponent<AudioSource>();
    }

    public void SlimeEnemyDead()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            _soundDead.Play();
        }
    }

    public void PlayerDestroyed()
    {
        if (PlayerPrefs.GetInt("sounds", 0) == 1)
        {
            _soundDestroy.Play();
        }
    }

    public void BonusTaken()
    {
        _soundBonus.Play();
    }
}