using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float InteractRadius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractRadius);
    }
    void Start()
    {
        
    }
    
    
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(UnityEngine.Collider collider)
    {
        Collider Player = collider.gameObject.GetComponent<Collider>();
        if (collider.CompareTag("Player"))
        {
            // make the slot machine glow

            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            Debug.Log("Glow start");
            return;
        }

    }
   
    private void OnTriggerExit(Collider other)
    {
        // Disable glow
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        Debug.Log("Glow End");
    }
}

