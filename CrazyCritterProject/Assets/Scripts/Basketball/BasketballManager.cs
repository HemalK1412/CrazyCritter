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

    [SerializeField] SaveManager saveManager;
    [SerializeField] private MiniGamestimer miniGamestimer;
    [SerializeField] private ScoreDisplay scoreDisplay;

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
        if (scoreDisplay.Score < 15)
        {
            EndScoreText.text = $"Awwww! You lost 100 nuts!";
        }
        else
        {
            EndScoreText.text = $"Well done! You won 150 nuts!";
        }

    }

    public void MiniGameEndContinuePressed()
    {
        if (DataBank.Instance != null)
        {
            if (scoreDisplay.Score < 15)
            {
                DataBank.Instance.MyStats.Nuts -= 100;
            }
            else
            {
                DataBank.Instance.MyStats.Nuts += 150;
            }
        }

        DataBank.Instance.MyStats.DayCount++;
        saveManager.Save();
        SceneManager.LoadScene("Casino");
    }

    private void Reset()
    {
        BallLauncher = FindObjectOfType<BallLauncher>(true);
        CameraRotation = FindObjectOfType<CameraRotation>(true);
    }
}
