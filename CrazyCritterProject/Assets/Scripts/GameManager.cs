using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject p_Player;
    public Rigidbody p_Rigidbody;

    [SerializeField] DataBank dataBank;

    public TextMeshProUGUI PauseCanvas;
    public TextMeshProUGUI HUD;

    public bool PauseGameOnStart = true;
    public bool isPaused;

    public int TargetScore = 1000; //To be confirmed

    private void Awake()
    {

        p_Player = GameObject.FindGameObjectWithTag("Player");
        if (p_Player == null) return;
        p_Rigidbody = p_Player.GetComponent<Rigidbody>();
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
            PauseCanvas.gameObject.SetActive(true);
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (p_Rigidbody == null) return;
        isPaused = true;


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

