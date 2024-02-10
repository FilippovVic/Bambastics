using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public float _bestScore;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    public static Progress Instance;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }
}