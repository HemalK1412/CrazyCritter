using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoFloorUI : MonoBehaviour
{

    public GameObject GameManager;


    [SerializeField] Button InitialStart;
    [SerializeField] Button Resume;



    [SerializeField] Canvas InitialStartCanvas;
    [SerializeField] Canvas PauseScreen;

    SaveManager SaveManager;




    private void Awake()
    {
        Time.timeScale = 0f;

    }

    private void Start()
    {
        // Load Data form the save system and assign to UI

    }

    public void InitialStartButtonPressed()
    {
        InitialStartCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    


    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
    public void ResumeButtonPressed()
    {
        PauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    /*
    private void OnDestroy()
    {
        SaveManager.Save();
    }
    */

}
