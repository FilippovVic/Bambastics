using TMPro;
using UnityEngine;

public class MultiplierText : MonoBehaviour
{
    [SerializeField] private TMP_Text _multiplierText;

    private void Update()
    {
        if (PlayerPrefs.GetInt("Multiplier") == 50)
        {
            _multiplierText.text = PlayerPrefs.GetInt("Multiplier", 1).ToString();
            _multiplierText.color = Color.yellow;
        }
        else {
            _multiplierText.text = PlayerPrefs.GetInt("Multiplier", 1).ToString();
            _multiplierText.color = Color.white;
        }
    }
}