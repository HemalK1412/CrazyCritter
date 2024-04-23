using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float chaseDistance = 5f;
    public float captureDistance = 1f;

    [SerializeField] private NavMeshPatrol patrol;
    private bool isChasing = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
    void Update()
    {
        if (!isChasing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance)
            {
                isChasing = true;
                patrol.enabled = false;
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().destination = player.position;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > chaseDistance)
            {
                isChasing = false;
                patrol.enabled = true;
            }
            else if (distanceToPlayer <= captureDistance)
            {
                Debug.Log("You have been caught.");
            }
        }
    }
}