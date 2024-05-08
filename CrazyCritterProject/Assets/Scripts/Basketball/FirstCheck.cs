using UnityEngine;
using System.Collections;

public class FirstCheck : MonoBehaviour 
{
	void OnTriggerEnter(Collider collider)
    {
        SecondCheck trigger = GetComponentInChildren<SecondCheck>();
        trigger.ExpectCollider(collider);
    }
}
