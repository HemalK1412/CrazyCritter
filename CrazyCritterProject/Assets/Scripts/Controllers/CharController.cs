using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    private CharacterController characterController;


    public float speed = 10f;
    public float lookSmooth = 0.05f;
    public float directionSmooth = 0.02f;

    private Vector3 inputDirection = Vector3.zero;
    private Vector3 effectiveDirection = Vector3.zero;

    private void Awake()
    {
        characterController = GetComponent <CharacterController>();
    }

    private void Update()
    {
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        float movementVertical = Input.GetAxisRaw("Vertical");

        inputDirection.x = movementHorizontal;
        inputDirection.y = movementVertical;
        inputDirection.Normalize();

        if(inputDirection.magnitude > 0.1)
        {
            float lookAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float effectiveAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.y, lookAngle, lookSmooth);
            transform.rotation = Quaternion.Euler(0, effectiveAngle, 0);
        }

        effectiveDirection = Vector3.Lerp(effectiveDirection, inputDirection, directionSmooth);
        characterController.Move(effectiveDirection * speed * Time.deltaTime);
    }
}
