using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CutScene : MonoBehaviour
{
    public Transform[] Teleports;
    public Transform[] Lerps;
    public float lerpDuration = 3f;

    public GameObject CutSceneCluster;

    [SerializeField] GameObject GameCamera;
    [SerializeField] GameObject HUD;

    [SerializeField] NavMeshPatrol enemyPatrol;
    [SerializeField] NavMeshAgent enemyAgent;
    [SerializeField] SmoothControl smoothControl;

    [SerializeField] ColorBlindDropdown colorBlindDropdown;

    [SerializeField] SaveManager saveManager;
    private void Awake()
    {
        //colorBlindDropdown.MenuValue = DataBank.Instance.MyStats.ColorBlindEnum;

        if (DataBank.Instance.MyStats.CutSceneDisplayed == true)
        {
            Destroy(CutSceneCluster);
        }

        GameCamera.SetActive(false);
    }
    private void Start()
    {
        smoothControl.enabled = false;
        HUD.SetActive(false);

        enemyPatrol.enabled = false;
        enemyAgent.enabled = false;


        StartCoroutine(TeleportLerpRoutine());
    }

    private IEnumerator TeleportLerpRoutine()
    {
        for (int i = 0; i < Teleports.Length; i++)
        {
            transform.position = Teleports[i].position;
            transform.rotation = Teleports[i].rotation;
            float elapsedtime = 0;
            while (elapsedtime < lerpDuration)
            {
                elapsedtime += Time.deltaTime;
                transform.position = Vector3.Lerp(Teleports[i].position, Lerps[i].position, elapsedtime / lerpDuration);
                yield return null;
            }

        }

        smoothControl.enabled = true;

        HUD.SetActive(true);

        enemyAgent.enabled = true;
        enemyPatrol.enabled = true;

        DataBank.Instance.MyStats.CutSceneDisplayed = true;
        saveManager.Save();
        GameCamera.SetActive(true);
        Destroy(CutSceneCluster);

    }
}