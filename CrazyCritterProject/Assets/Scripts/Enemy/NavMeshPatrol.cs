using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    void Start()
    {
        agent.destination = waypoints[currentWaypoint].position;
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }

            agent.destination = waypoints[currentWaypoint].position;
        }
    }
}