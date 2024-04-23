using UnityEngine;

public class DestroyNuts : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nuts"))
        {

            Destroy (collision.gameObject, 3.0f);

            
        }
    }
}
