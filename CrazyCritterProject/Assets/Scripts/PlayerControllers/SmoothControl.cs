using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothControl : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    private float verticalAxisValue;
    private float horizontalAxisValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = false;
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
    }

    void Start()
    {

    }

    void Update()
    {
        horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        verticalAxisValue = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.forward * verticalAxisValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Turn()
    {
        float turn = horizontalAxisValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    
}
