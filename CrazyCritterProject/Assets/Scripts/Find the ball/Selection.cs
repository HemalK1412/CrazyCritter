using UnityEditor;
using UnityEngine;

public class Selection : MonoBehaviour
{

    public float raycastDistance = 10f;
    public bool NutFound;


    [SerializeField] FindTheNutManager findTheNutManager;


    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray , out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (hit.transform.childCount > 1)
                {
                    NutFound = true;
                    findTheNutManager.MiniGameEnd();
                    enabled = false;
                }
                else
                {
                    NutFound= false;
                    findTheNutManager.MiniGameEnd();
                    enabled = false;
                }
            }
        }
    }
}