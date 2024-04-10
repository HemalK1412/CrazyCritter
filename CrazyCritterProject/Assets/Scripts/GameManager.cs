using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] int gm_DayoftheWeek;
    [SerializeField] int gm_Nuts;
    [SerializeField] float[] gm_position;
    TMP_Text Daycount;
    TMP_Text Nuts;
    TMP_Text Position;



    GameObject p_Player;
    Rigidbody p_Rigidbody;

    public Canvas InitialStartCanvas;
    [SerializeField] Canvas PauseCanvas;


    private void Awake()
    {

        p_Player = GameObject.FindGameObjectWithTag("Player");
        p_Rigidbody = p_Player.GetComponent<Rigidbody>();
    }


    public void Start()
    {

    }

    public void FixedUpdate()
    {

    }


    public void InitialStartButtonPressed()
    {
        InitialStartCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;

        p_Rigidbody.isKinematic = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
