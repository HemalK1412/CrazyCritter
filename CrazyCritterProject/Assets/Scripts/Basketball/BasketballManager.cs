using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BasketballManager : MonoBehaviour
{
    public Canvas BasketballMiniGameStartCanvas;
    public Canvas BasketballMiniGameHUD;
    public Canvas BasketballMiniGameEndCanvas;

    public BallLauncher BallLauncher;
    public CameraRotation CameraRotation;

    [SerializeField] private MiniGamestimer miniGamestimer;
    BasketballScoreKeeper basketballScoreKeeper;
    SaveManager saveManager;

    private void Awake()
    {
        BasketballMiniGameHUD.gameObject.SetActive(false);
        BasketballMiniGameStartCanvas.gameObject.SetActive(true);
        BasketballMiniGameEndCanvas.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;

        //p_player = GameObject.FindGameObjectWithTag("Player");
        if (BallLauncher == null) return;
        CameraRotation.enabled = false;
        BallLauncher.enabled = false;

    }
    

    private void FixedUpdate()
    {
        if (miniGamestimer.remainingTime <= 0)
        {
            MiniGameEnd();
        }
    }

    public void MiniGameStartButtonPressed()
    {
        CameraRotation.enabled = true;
        BallLauncher.enabled = true;
        BasketballMiniGameStartCanvas.gameObject.SetActive(false);
        BasketballMiniGameHUD.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MiniGameEnd()
    {
        CameraRotation.enabled = false;
        BallLauncher.enabled = false;
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

    private void Reset()
    {
        BallLauncher = FindObjectOfType<BallLauncher>(true);
        CameraRotation = FindObjectOfType<CameraRotation>(true);
    }
}
