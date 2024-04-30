using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelResume : MonoBehaviour
{
    
    public GameManager gameManager;

    public void ResumeButtonPressed()
    {
        //gameManager.isPaused = false;
        gameManager.ResumeGame();
        gameObject.SetActive(false);
    }
}