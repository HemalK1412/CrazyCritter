using UnityEngine;

public class CasinoMasterUI : MonoBehaviour
{

    [SerializeField] DataBank dataBank;

    private void Awake()
    {
        dataBank = GameObject.Find("DataBank").GetComponent<DataBank>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
