using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBank : MonoBehaviour
{
    private static DataBank instance;

    public Stats MyStats;
    SaveManager SaveManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SaveManager = FindAnyObjectByType<SaveManager>();
        if(SaveManager == null)return;
        SaveManager.Load();
    }
}
