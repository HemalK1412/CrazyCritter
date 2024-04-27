using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BasketballManager : MonoBehaviour
{
    public Canvas BasketballMiniGameStartCanvas;
    public Canvas BasketballMiniGameHUD;
    public Canvas BasketballMiniGameEndCanvas;

    public BallLauncher BallLauncher;
    public CameraRotation CameraRotation;

    public TextMeshProUGUI EndScoreText;

    [SerializeField] private MiniGamestimer miniGamestimer;
    [SerializeField] private ScoreDisplay scoreDisplay;

    [SerializeField] DataBank dataBank;

    private void Awake()
    {
        dataBank = GameObject.Find("DataBank").GetComponent<DataBank>();

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

        EndScoreText.text = "Nuts Gathered = " + scoreDisplay.Score.ToString();
        //get the score to the Game manager and save it.
    }

    public void MiniGameEndContinuePressed()
    {
        dataBank.MyStats.Nuts = dataBank.MyStats.Nuts + scoreDisplay.Score;
        dataBank.MyStats.DayCount = dataBank.MyStats.DayCount + 1;
        SceneManager.LoadScene("Casino");
    }

    private void Reset()
    {
        BallLauncher = FindObjectOfType<BallLauncher>(true);
        CameraRotation = FindObjectOfType<CameraRotation>(true);
    }
}
