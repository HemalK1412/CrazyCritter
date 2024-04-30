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

    [SerializeField] float powerUpDuration;
    [SerializeField] float powerUpSpeed;
    [SerializeField] float powerUpTurn;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 movementDir = transform.forward * (verticalAxisValue * speed);
        rb.velocity = new Vector3(movementDir.x, rb.velocity.y, movementDir.z);
    }

    void Turn()
    {
        float turn = horizontalAxisValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    // Chose  to put the  powerup speed increase here as the collision wont matter in the Casino Floor and would reduce script calls usind the GetComponent function.

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpeedPowerUp"))
        {
            StartCoroutine(SpeedandTurnSpeedIncrease());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedandTurnSpeedIncrease()
    {
        float originalSpeed = speed;
        float originalTurnSpeed = turnSpeed;

        speed += powerUpSpeed;
        turnSpeed += powerUpTurn;

        yield return new WaitForSeconds(powerUpDuration);

        speed = originalSpeed;
        turnSpeed = originalTurnSpeed;
    }


}
