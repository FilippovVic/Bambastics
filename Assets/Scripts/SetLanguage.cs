using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLanguage : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    public void FixedUpdate()
    {
        if (PlayerPrefs.GetString("language") == "en")
        {
            GetComponent<TMP_Text>().text = _en;
        }
        else if (PlayerPrefs.GetString("language") == "ru")
        {
            GetComponent<TMP_Text>().text = _ru;
        }
        else {
            GetComponent<TMP_Text>().text = _en;
        }
    }
}