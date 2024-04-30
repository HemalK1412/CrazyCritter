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
    }

    private void Start()
    {
        SaveManager = FindAnyObjectByType<SaveManager>();
        if(SaveManager == null)return;
        SaveManager.Load();
    }
}
