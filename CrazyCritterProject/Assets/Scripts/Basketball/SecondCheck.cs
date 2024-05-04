using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SecondCheck : MonoBehaviour
{
    Collider expectedCollider;
    [SerializeField] BasketMove basketMove;
    [SerializeField] ScoreDisplay scoreDisplay;
    public UnityEvent onScore;

	public void ExpectCollider(Collider collider)
    {
        expectedCollider = collider;
    }

	void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider == expectedCollider)
        {
            basketMove.ChangeRingLocation();
            Destroy(expectedCollider.gameObject);
            scoreDisplay.IncreaseScore();
            onScore.Invoke();
		}
	}
}
