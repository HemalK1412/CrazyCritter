using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerarotatetrial : MonoBehaviour
{
    private Vector3 targetchords;
    public Transform player;

    public float Turnspeed = 2.0f;
    public Quaternion Turnto;

    public Vector3 offset;


    private void Start()
    {
        targetchords = player.transform.position;
    }

    void Update()
    {
        Turnto = player.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, Turnto, Time.deltaTime * Turnspeed);
        transform.position = player.transform.position + offset;

    }
}
