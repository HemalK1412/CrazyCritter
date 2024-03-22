using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public int NoofDays;




    private void FixedUpdate()
    {
        if(Input.GetKeyDown("i"))
        {
            NoofDays++;
        }
    }
}
