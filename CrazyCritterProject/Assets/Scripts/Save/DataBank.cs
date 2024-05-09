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

        PlayerPrefs.SetInt("InitialCurrency", 500);
        PlayerPrefs.SetInt("TargetScore", 1000);


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

    }


    private void Start()
    {
        SaveManager = FindAnyObjectByType<SaveManager>();
        if(SaveManager == null)return;
        SaveManager.Load();
    }
}
