using UnityEngine;

public class Score : MonoBehaviour
{
    public float _currentScore;
    public int _multiplier;

    private void Start()
    {
        _multiplier = 1;
        _currentScore = 0;
        PlayerPrefs.SetInt("Multiplier", _multiplier);
        PlayerPrefs.SetFloat("finalScore", 0);
    }

    private void Update()
    {
        _currentScore += Time.deltaTime * PlayerPrefs.GetInt("Multiplier", 1);
    }

    public float GetScore()
    {
        return Mathf.Round(_currentScore);
    }

    public void ResetMultiplier()
    {
        _multiplier = 1;
        PlayerPrefs.SetInt("Multiplier", _multiplier);
    }

    public void AdjustMltiplier()
    {
        if (PlayerPrefs.GetInt("Multiplier", 1) < 50) {
            _multiplier = PlayerPrefs.GetInt("Multiplier", 1);
            _multiplier += 1;
            PlayerPrefs.SetInt("Multiplier", _multiplier);
        }
    }
}