using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject PlayerCamera;

    public float balloffset;
    public float BallThrowingForce;

    public bool IsHoldingBall = true;

    private void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    private void FixedUpdate()
    {
        if (IsHoldingBall)
        {
            ball.transform.position = PlayerCamera.transform.position + (PlayerCamera.transform.forward * balloffset);

        }
    }
}
