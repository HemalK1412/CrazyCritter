using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MiniGameLoader : MonoBehaviour
{
    public string MiniGameScene;
    public bool PlayerisHere;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerisHere = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerisHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerisHere = false;
    }

    private void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.E) && PlayerisHere == true)
        {
            Debug.Log("Scene Switch to : " + MiniGameScene);
            SceneManager.LoadScene(MiniGameScene);
        }
    }
}
