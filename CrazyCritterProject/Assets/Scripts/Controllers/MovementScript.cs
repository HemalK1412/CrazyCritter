using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float p_Speed;
    public float p_TurnSpeed;
    // public Transform p_Camera;
    
    private Rigidbody p_Rigidbody;

    private float p_HorizontalAxisValue;
    private float p_VerticalAxisValue;

    private Transform p_Transform;
    private float p_RotationSpeed;
    private Quaternion p_TargetRotation;
    
    void Awake()
    {
        p_Rigidbody = this.GetComponent<Rigidbody>();
        p_Transform = this.transform;
    }

    private void OnEnable()
    {
        p_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        p_Rigidbody.isKinematic = true;
    }

    void Start()
    {
        p_TargetRotation = p_Transform.rotation;
        p_RotationSpeed = 10.0f;
    }

    void Update()
    {
        p_HorizontalAxisValue = Input.GetAxisRaw("Horizontal");

        p_VerticalAxisValue = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = p_Transform.forward * p_VerticalAxisValue * p_Speed * Time.deltaTime;

        if (Input.GetKey("w"))
        {
            p_Rigidbody.MovePosition(p_Rigidbody.position + movement);
        }

        if (Input.GetKey("s"))
        {
            p_Rigidbody.MovePosition(p_Rigidbody.position + movement);
        }
    }

    void Turn()
    {
        p_TargetRotation = Quaternion.AngleAxis(p_HorizontalAxisValue * p_TurnSpeed * Time.deltaTime, p_Transform.up) * p_TargetRotation;

        p_Transform.rotation = Quaternion.Lerp(p_Transform.rotation, p_TargetRotation, Time.deltaTime * p_RotationSpeed);
    }


    /*
     *  All comments should be variables and their initiation should be for this function so uncomment them
    void LateUpdate()
    {
        p_Camera.position = p_Transform.position + p_Transform.up * 5 + p_Transform.forward * -10;
        p_Camera.rotation = p_Transform.rotation;
    }
    */

}