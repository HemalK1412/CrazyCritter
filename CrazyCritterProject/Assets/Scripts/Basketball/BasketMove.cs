using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMove : MonoBehaviour
{
    public Collider MoveArea;
    public GameObject BasketRing;


    public void ChangeRingLocation()
    {
        Vector3 newLocation = RandomBasketLocation();

        BasketRing.transform.position = newLocation;

    }

    Vector3 RandomBasketLocation()
    {
        Vector3 randomPos = new Vector3(
                        Random.Range(MoveArea.bounds.min.x, MoveArea.bounds.max.x),
                        Random.Range(MoveArea.bounds.min.y, MoveArea.bounds.max.y),
                        3.5f
                    );
        return randomPos;
    }
}
