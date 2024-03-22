using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float p_Speed;
    public float p_TurnSpeed;
    // MOVEMENT AUDIO


    private Rigidbody p_Rigidbody;

    private float p_HorizontalAxisValue;

    private float p_VerticalAxisValue;


    void Awake()
    {
        p_Rigidbody = this.GetComponent<Rigidbody>();
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

    }

    void Update ()
    {
        //Cartesian X Object X
        p_HorizontalAxisValue = Input.GetAxisRaw("Horizontal");

        //Cartesian Y Object Z
        p_VerticalAxisValue = Input.GetAxisRaw("Vertical");

    }
    
    void FixedUpdate()
    {
        Move();
        Turn();
    }


    void Move()
    { 
        /*
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * p_Speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * p_Speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * p_Speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * p_Speed * Time.deltaTime);
        }
        */

        Vector3 movement = transform.forward * p_VerticalAxisValue * p_Speed * Time.deltaTime;

        if(Input.GetKey("w"))
        {
            p_Rigidbody.MovePosition(p_Rigidbody.position + movement);
        }
        // S input makes the character go forward for some reason
        if (Input.GetKey("s"))
        {
            p_Rigidbody.MovePosition(p_Rigidbody.position + movement);
        }
    }

    void Turn()
    {
        float turn = p_HorizontalAxisValue * p_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

        if(Input.GetKey("a"))
        {
            p_Rigidbody.MoveRotation(p_Rigidbody.rotation * turnRotation);
        }
        // D key inverse the rotation
        if (Input.GetKey("d"))
        {
            p_Rigidbody.MoveRotation(p_Rigidbody.rotation * turnRotation);
        }
    }


    // Save system testing

    /*
     * Update days and nut count for now and save the position
     * check if its updated in the Start Screen (using laod button)
     * Convert the current screen into the pause button
    */






}
