using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject p_Player;
    public Rigidbody p_Rigidbody;


    public Canvas PauseCanvas;
    public Canvas HUD;

    public bool PauseGameOnStart = true;
    public bool isPaused;

    public int TargetScore = 1000; //To be confirmed

    private void Awake()
    {
    }


    public void Start()
    {
        /*
        if (PauseCanvas == null) return;
        if (PauseGameOnStart)
        {
            PauseCanvas.gameObject.SetActive(false);
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
        */
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas == null) return;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (p_Rigidbody == null) return;
        isPaused = true;

        PauseCanvas.gameObject.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        if (p_Rigidbody == null) return;
        
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

}

