using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLoader : MonoBehaviour
{
    public string MiniGameScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Scene Switch to : " + MiniGameScene);
            SceneManager.LoadScene(MiniGameScene);
        }
    }
}
