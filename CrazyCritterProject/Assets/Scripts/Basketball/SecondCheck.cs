using UnityEngine;
using System.Collections;

public class SecondCheck : MonoBehaviour 
{
	Collider expectedCollider;
    BasketMove basketMove;
    ScoreDisplay scoreDisplay;

	public void ExpectCollider(Collider collider)
    {
        expectedCollider = collider;
    }

	void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider == expectedCollider)
        {
            //Increment scores

            basketMove.ChangeRingLocation();
            scoreDisplay.Score++;
		}
	}
}
