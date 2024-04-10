using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoFloorUI : MonoBehaviour
{
    public GameObject p_Player;
    Rigidbody p_Rigidbody;


    [SerializeField] Button InitialStart;
    [SerializeField] Button Resume;



    [SerializeField] Canvas InitialStartCanvas;
    [SerializeField] Canvas PauseCanvas;

    public SaveManager SaveManager;




    private void Awake()
    {
        Time.timeScale = 0f;
        p_Player = GameObject.FindGameObjectWithTag("Player");
        p_Rigidbody = p_Player.GetComponent<Rigidbody>();
        p_Rigidbody.isKinematic = false;

    }

    private void Start()
    {
        // Load Data form the save system and assign to UI

    }

    public void InitialStartButtonPressed()
    {
        InitialStartCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;

        p_Rigidbody.isKinematic = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    


    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseCanvas.gameObject.SetActive(true);

            p_Rigidbody.isKinematic = false;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
    public void ResumeButtonPressed()
    {
        PauseCanvas.gameObject.SetActive(false);

        p_Rigidbody.isKinematic = true;
        Time.timeScale = 1f;
    }

    
    private void OnDestroy()
    {
        SaveManager.Save();
    }
    

}
