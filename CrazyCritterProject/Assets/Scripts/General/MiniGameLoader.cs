using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MiniGameLoader : MonoBehaviour
{
    public string MiniGameScene;
    public bool PlayerisHere;

    public GameObject PressE;

    [SerializeField] SaveManager saveManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerisHere = true;
            PressE.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerisHere = true;
            PressE.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerisHere = false;
        PressE.SetActive(false);
    }

    private void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.E) && PlayerisHere == true)
        {
            saveManager.Save();
            Debug.Log("Scene Switch to : " + MiniGameScene);
            SceneManager.LoadScene(MiniGameScene);
        }
    }
}
