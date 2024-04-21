using UnityEditor;
using UnityEngine;

public class Selection : MonoBehaviour
{
    Transform target;
    public float raycastDistance = 10f;
    public bool NutFound;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit))
        {
            if(hit.transform.CompareTag("Selectable"))
            {
                hit.transform.GetComponent<Material>().color = Color.yellow;
            }
            if (Input.GetMouseButtonDown(0))
            {

                if (hit.transform.childCount > 0)
                {
                    NutFound = true;
                    Debug.Log("Hit object has a child object.");
                }
                else
                {
                    NutFound= false;
                }
            }
        }
    }
}
