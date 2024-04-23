using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour 
{
	public GameObject NutPrefab;
    public float ThrowSpeed = 5.0f;
    
    public float Cooldown = 0.5f;
    private float lastThrowTime = 0.0f;
    
	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
	        if(Cooldown > Time.time - lastThrowTime)
			{
				return;
			}
	        lastThrowTime = Time.time;
            GameObject instance = Instantiate(NutPrefab);
            instance.transform.position = transform.position;
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            Camera camera = GetComponentInChildren<Camera>();
            rb.velocity = camera.transform.rotation * Vector3.forward * ThrowSpeed;
		}
    }
}
