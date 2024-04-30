using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollected : MonoBehaviour
{
    public bool GunPickup;
    //public bool HatPickup;

    public Canvas GunPickupCanvas;
    public Canvas HatPickupCanvas;

    [SerializeField] GameManager gameManager;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (GunPickup == true)
            {
                gameManager.isPaused = true;

                DataBank.Instance.MyStats.GunPickup = true;

                GunPickupCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Destroy(gameObject);

            }
            else
            {
                gameManager.isPaused = true;

                DataBank.Instance.MyStats.HatPickup = true;

                HatPickupCanvas.gameObject.SetActive(true);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.None;
                Destroy(gameObject);
            }
        }
    }
}
// The instantiated canvas will have a resume button that calls Game Manager Resume Game
