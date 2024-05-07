using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBank : MonoBehaviour
{
    public static DataBank Instance;

    public Stats MyStats;
    SaveManager SaveManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if(Instance.MyStats.DayCount == 0)
        {
            MyStats.DayCount++;
        }

        PlayerPrefs.SetInt("InitialCurrency", 500);
        PlayerPrefs.SetInt("TargetScore", 1000);
        PlayerPrefs.SetInt("CostofMinigame", 50);


        if (!PlayerPrefs.HasKey("NewGame"))
        {
            MyStats.Nuts = PlayerPrefs.GetInt("InitialCurrency");
            //Creates a key when startbutton is pressed.
        }
    }


    private void Start()
    {
        SaveManager = FindAnyObjectByType<SaveManager>();
        if(SaveManager == null)return;
        SaveManager.Load();
    }
}
