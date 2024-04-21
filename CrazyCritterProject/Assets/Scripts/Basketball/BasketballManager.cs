using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballManager : MonoBehaviour
{
    public Canvas BasketballMiniGameStartCanvas;
    public Canvas BasketballMiniGameHUD;
    public Canvas BasketballMiniGameEndCanvas;

    public GameObject p_player;

    MiniGamestimer miniGamestimer;
    BasketballScoreKeeper basketballScoreKeeper;
    SaveManager saveManager;

    private void Awake()
    {
        miniGamestimer = FindAnyObjectByType<MiniGamestimer>();


        BasketballMiniGameHUD.gameObject.SetActive(false);
        BasketballMiniGameStartCanvas.gameObject.SetActive(true);
        BasketballMiniGameEndCanvas.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;

        p_player = GameObject.FindGameObjectWithTag("Player");
        if (p_player == null) return;
        p_player.GetComponent<CameraRotation>().enabled = false;
        p_player.GetComponent<BallLauncher>().enabled = false;

    }


    private void FixedUpdate()
    {

        if (miniGamestimer.remainingTime <= 55)
        {
            MiniGameEnd();
        }
    }

    public void MiniGameStartButtonPressed()
    {
        p_player.GetComponent<CameraRotation>().enabled = true;
        p_player.GetComponent<BallLauncher>().enabled = true;
        BasketballMiniGameStartCanvas.gameObject.SetActive(false);
        BasketballMiniGameHUD.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MiniGameEnd()
    {
        p_player.GetComponent<CameraRotation>().enabled = false;
        p_player.GetComponent<BallLauncher>().enabled = false;
        BasketballMiniGameHUD.gameObject.SetActive(false);
        BasketballMiniGameEndCanvas.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;


        //get the score to the Game manager and save it.
    }

    public void MiniGameEndContinuePressed()
    {
        //saveManager.Save();
        SceneManager.LoadScene("Casino");
    }
}
