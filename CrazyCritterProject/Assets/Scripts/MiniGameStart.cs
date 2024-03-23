using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStart : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Scene Switch");
            SceneManager.LoadScene("Catch the Nuts");


        }
    }
}
