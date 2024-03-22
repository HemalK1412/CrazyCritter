using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nuts") == true)
        {
            Destroy(other.gameObject);
        }
    }
}
