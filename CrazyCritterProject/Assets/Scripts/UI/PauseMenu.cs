using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameObject p_Player;
    Rigidbody p_Rigidbody;

    //public SaveManager SaveManager;


    private void Awake()
    {
        Time.timeScale = 0f;
        p_Player = GameObject.FindGameObjectWithTag("Player");
        p_Rigidbody = p_Player.GetComponent<Rigidbody>();
        p_Rigidbody.isKinematic = false;
        Cursor.lockState = CursorLockMode.None;
    }
     

    private void FixedUpdate()
    {
        // Stat pull from save managaer and display
    }



    public void ResumeButtonPressed()
    {
        gameObject.SetActive(false);

        Cursor.lockState= CursorLockMode.Locked;

    }

}
