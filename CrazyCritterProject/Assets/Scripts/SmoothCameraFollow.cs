using System;
using Unity.VisualScripting;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothtime;

    private Vector3 currentveloicity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position;
        
    }

    private void LateUpdate()
    {


        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentveloicity, smoothtime);


    }

}
