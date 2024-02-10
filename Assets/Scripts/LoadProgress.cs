using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    public float _bestScore;
}

public class LoadProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerInfoText;

    public PlayerInformation PlayerInfo;

    [DllImport("__Internal")]
    private static extern void GetDataAgain();

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInformation>(value);
        PlayerPrefs.SetFloat("BestScore", PlayerInfo._bestScore);
    }

    private void Start()
    {
        if (PlayerPrefs.GetFloat("BestScore") == 0)
        {
            try
            {
                GetDataAgain();
            }
            catch
            {}
        }
    }

    private void FixedUpdate()
    {
        _playerInfoText.text = PlayerPrefs.GetFloat("BestScore", 0).ToString();
    }
}