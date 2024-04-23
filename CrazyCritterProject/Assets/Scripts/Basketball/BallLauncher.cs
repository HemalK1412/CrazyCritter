using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour 
{
	public GameObject NutPrefab;
    public float ThrowSpeed = 5.0f;

    void Start() 
    {
    
    }
	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject instance = Instantiate(NutPrefab);
            instance.transform.position = transform.position;
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            Camera camera = GetComponentInChildren<Camera>();
            rb.velocity = camera.transform.rotation * Vector3.forward * ThrowSpeed;
		}
    }
}
