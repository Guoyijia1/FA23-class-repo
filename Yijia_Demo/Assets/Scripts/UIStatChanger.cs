using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatChanger : MonoBehaviour
{
    public PlayerPrefs.Stat thisStat;
    public int starValue = 10;

    public TextMeshProUGUI statTMP;

    public void Start()
    {
        PlayerPrefs.playerStats.Add(thisStat, statvalue);
        statTMP.text = Player
    }



}
