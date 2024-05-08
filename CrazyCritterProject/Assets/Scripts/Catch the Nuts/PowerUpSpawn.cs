using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] MiniGamestimer miniGamestimer;
    [SerializeField] Collider PowerUpSpawnCollider;
    [SerializeField] GameObject powerUpObject;

    private bool powerUpSpawned = false;

    void Update()
    {
        if (miniGamestimer.remainingTime <= 40f && miniGamestimer.remainingTime >= 20f && !powerUpSpawned)
        {
            powerUpObject.SetActive(true);
            powerUpObject.transform.position = 
                new Vector3(Random.Range(PowerUpSpawnCollider.bounds.min.x, PowerUpSpawnCollider.bounds.max.x),
                Random.Range(PowerUpSpawnCollider.bounds.min.y, PowerUpSpawnCollider.bounds.max.y), 1f);
            powerUpSpawned = true;
        }
        else if (miniGamestimer.remainingTime < 20f)
        {
            powerUpObject.SetActive(false);
            powerUpSpawned = false;
        }

    }
}
