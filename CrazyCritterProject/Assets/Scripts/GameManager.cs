using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject p_Player;
    public Rigidbody p_Rigidbody;


    public Canvas PauseCanvas;
    public Canvas HUD;

    public bool PauseGameOnStart = true;
    public bool isPaused;

    public GameObject GunPickup;
    public GameObject HatPickup;
    public Transform GunPickUpLocation;
    public Transform HatPickupLocation;

    public int TargetScore = 1000; //To be confirmed

    private void Awake()
    {
        if (DataBank.Instance.MyStats.GunPickup == false)
        {
            GunPickup.transform.position = GunPickUpLocation.transform.position;
        }
        else
        {
            Destroy(GunPickup);
        }

        if (DataBank.Instance.MyStats.HatPickup == false)
        {
            HatPickup.transform.position = HatPickupLocation.transform.position;
        }
        else
        {
            Destroy(HatPickup);
        }
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

