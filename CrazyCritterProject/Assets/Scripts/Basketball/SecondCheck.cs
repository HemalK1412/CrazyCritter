using UnityEngine;
using System.Collections;

public class SecondCheck : MonoBehaviour 
{
	Collider expectedCollider;
    BasketMove basketMove;

	public void ExpectCollider(Collider collider)
    {
        expectedCollider = collider;
    }

	void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider == expectedCollider)
        {
    		//Increment scores
            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
    		scoreKeeper.IncrementScore();
            basketMove.ChangeRingLocation();
		}
	}
}
