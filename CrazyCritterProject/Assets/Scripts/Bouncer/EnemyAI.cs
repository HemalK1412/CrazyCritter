using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float chaseDistance = 5f;
    public float captureDistance = 1f;
    public int NutToDeduct;

    [SerializeField] private NavMeshPatrol patrol;
    private bool isChasing = false;
    
    public UnityEvent OnChase;
    public UnityEvent OnCaughtPlayer;

    [SerializeField] SaveManager saveManager;

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
                OnChase?.Invoke();
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
                if(DataBank.Instance != null)
                    DataBank.Instance.MyStats.Nuts -= NutToDeduct;
                
                Debug.Log("You have been caught.");
                OnCaughtPlayer?.Invoke();
                saveManager.Save();
                SceneManager.LoadScene("Casino");
            }
        }
    }
}