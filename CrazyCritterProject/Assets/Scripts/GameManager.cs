using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    public int TargetScore = 100; //To be confirmed


    public int gm_DayoftheWeek = 1;
    public int gm_MinigamesCompleted = 0;
    public int gm_Nuts;
    public Vector3 Bouncer_position;


    public bool SpeedpowerUP;


    public GameObject Bouncer;
    public GameObject p_Player;
    public Rigidbody p_Rigidbody;


    public bool isPaused;
    public GameObject PauseCanvas;

    private void Awake()
    {

        p_Player = GameObject.FindGameObjectWithTag("Player");
        if (p_Player == null) return;
        p_Rigidbody = p_Player.GetComponent<Rigidbody>();
    }


    public void Start()
    {
        if (PauseCanvas == null) return;
        PauseCanvas.SetActive(false);
        PauseGame();
    }

    public void Update()
    {
        /*
        if (isPaused == true)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
        */

        //Bouncer_position = Bouncer.transform.position;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas == null) return;
            PauseCanvas.gameObject.SetActive(true);
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (p_Rigidbody == null) return;
        p_Rigidbody.isKinematic = false;
        //p_Player.SetActive(false);
        isPaused = true;


        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        if (p_Rigidbody == null) return;
        p_Rigidbody.isKinematic = true;
        //p_Player.SetActive(true);
        
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    void MinigamesUpdate()
    {
        gm_MinigamesCompleted++;
        if (gm_MinigamesCompleted == 2)
        {
            gm_DayoftheWeek++;
            gm_MinigamesCompleted = 0;
        }
    }


    void GameOver()
    {
        if(gm_DayoftheWeek == 6)
        {
            if (gm_Nuts >= TargetScore)
            {
                //Win cutscene
            }
            else
            {
                //Lose cutscene

                //Restart the game
            }
        }
    }


}

