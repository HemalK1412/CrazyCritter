using UnityEditor;
using UnityEngine;

public class Selection : MonoBehaviour
{

    public float raycastDistance = 10f;
    public bool NutFound;

    public Canvas FindTheNutMiniGameHUD;
    public Canvas FindTheNutMiniGameEndCanvas;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray , out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (hit.transform.childCount > 0)
                {
                    NutFound = true;
                    Debug.Log("Hit object has a child object.");
                    MiniGameEnd();
                    //change the text to victory
                }
                else
                {
                    NutFound= false;
                    MiniGameEnd();
                }
            }
        }

    }
    public void MiniGameEnd()
    {
        FindTheNutMiniGameHUD.gameObject.SetActive(false);
        FindTheNutMiniGameEndCanvas.gameObject.SetActive(true);
        this.enabled = false;
    }
}
// Change mat changes to OnMouseEnter 
