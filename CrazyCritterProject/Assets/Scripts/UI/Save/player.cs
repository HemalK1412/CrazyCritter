using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    // Script placed on the Player Character.

    public GameManager GameManager;

    public Stats MyStats;

    /*private void FixedUpdate()
    {
        //Does this need to be in Fixed Update

        MyStats.DayCount = GameManager.gm_DayoftheWeek;
        MyStats.Nuts =  GameManager.gm_Nuts;
        MyStats.MinigamesCompleted  = GameManager.gm_MinigamesCompleted;

        MyStats.Speedpowerups = GameManager.SpeedpowerUP;


        MyStats.p_Position.x = gameObject.transform.position.x;
        MyStats.p_Position.y = gameObject.transform.position.y;
        MyStats.p_Position.z = gameObject.transform.position.z;

        // If the scene load back every time fromt he start can I omit the Guard save and have the Game Manager temp save it with the DontDestroyOnLoad() function.
        
        MyStats.Bouncer_Position.x = GameManager.Bouncer_position.x;
        MyStats.Bouncer_Position.y = GameManager.Bouncer_position.y;
        MyStats.Bouncer_Position.z = GameManager.Bouncer_position.z;

    }*/

    /*
    public void SerializableVector3(Vector3 p_Position)
    {
        MyStats.p_Position.x = p_Position.x;
        MyStats.p_Position.y = p_Position.y;
        MyStats.p_Position.z = p_Position.z;
    }
    */
}
