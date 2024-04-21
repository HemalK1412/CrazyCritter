using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutParent : MonoBehaviour
{
    public GameObject Nut;
    public GameObject ParentCup;

    public void ParentToCup()
    {
        Nut.transform.SetParent(ParentCup.transform, worldPositionStays: true);
    }

}
