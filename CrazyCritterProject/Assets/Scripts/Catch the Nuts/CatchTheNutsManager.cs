using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CatchTheNutsManager : MonoBehaviour
{
    public Canvas MiniGameStartCanvas;
    public Canvas MiniGameHUD;

    public Button MiniGameStartButton;

    public GameObject p_player;
    public Rigidbody p_Rigidbody;

    public GameObject MG_Spawner;
    public GameObject MG_Destroyer;

    MiniGamestimer MiniGamestimer;
    CatchTheNutsScoreKeeper catchTheNutsScoreKeeper;
   
    

    void Awake()
    {
        MiniGameHUD.gameObject.SetActive(false);
        MiniGameStartCanvas.gameObject.SetActive(true);

        p_player = GameObject.FindGameObjectWithTag("Player");
        if (p_player == null ) return;
        p_Rigidbody = p_player.GetComponent<Rigidbody>();
        p_Rigidbody.isKinematic = false;


    }

    private void Update()
    {
        if (MiniGamestimer.remainingTime == 00 )
        {
            MiniGameEnd();
        }
    }

    void MiniGameStartButtonPressed()
    {

        MiniGameStartCanvas.gameObject.SetActive(false);
        MiniGameHUD.gameObject.SetActive(true);

        p_Rigidbody.isKinematic = true;
        MG_Spawner.SetActive(true);
        MG_Destroyer.SetActive(true);
    }

    void MiniGameEnd()
    {
        MG_Destroyer.SetActive(false);
        MG_Spawner.SetActive(false);

        p_Rigidbody.isKinematic = false;

        MiniGameHUD.gameObject.SetActive(false);
        MiniGameStartCanvas.gameObject.SetActive(true);

        //get the score to the Game manager and save it.
    }
}
