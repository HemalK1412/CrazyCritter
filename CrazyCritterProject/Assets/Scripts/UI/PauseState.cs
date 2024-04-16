using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseState : MonoBehaviour
{
    
    public GameManager gameManager;

    public void ResumeButtonPressed()
    {
        //gameManager.isPaused = false;
        gameManager.ResumeGame();
        gameObject.SetActive(false);
    }
}