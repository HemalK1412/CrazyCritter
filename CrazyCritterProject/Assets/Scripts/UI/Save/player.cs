using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    public GameManager GameManager;

    public Stats MyStats;

    private void FixedUpdate()
    {




        MyStats.p_Position.x = gameObject.transform.position.x;
        MyStats.p_Position.y = gameObject.transform.position.y;
        MyStats.p_Position.z = gameObject.transform.position.z;

        

    }

}
