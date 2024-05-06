using System.Collections;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public Transform[] Teleports;
    public Transform[] Lerps;
    public float lerpDuration = 3f;

    public GameObject CutSceneCluster;

    [SerializeField] GameObject HUD;
    [SerializeField] EnemyAI enemyAI;
    [SerializeField] SmoothControl smoothControl;

    private void Awake()
    {
        if (DataBank.Instance.MyStats.CutSceneDisplayed == true)
        {
            Destroy(CutSceneCluster);
        }
    }
    private void Start()
    {
        smoothControl.enabled = false;
        HUD.SetActive(false);
        enemyAI.enabled = false;
        StartCoroutine(TeleportLerpRoutine());
    }

    private IEnumerator TeleportLerpRoutine()
    {
        /*
        transform.position = Teleports[1].position;
        float elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(Teleports[1].position, Lerps[1].position, elapsedTime / lerpDuration);
            yield return null;
        }

        transform.position = Teleports[2].position;
        elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(Teleports[2].position, Lerps[2].position, elapsedTime / lerpDuration);
            yield return null;
        }

        transform.position = Teleports[3].position;
        elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(Teleports[3].position, Lerps[3].position, elapsedTime / lerpDuration);
            yield return null;
        }
        transform.position = Teleports[4].position;
        elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(Teleports[4].position, Lerps[4].position, elapsedTime / lerpDuration);
            yield return null;
        }
        */
        

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
        enemyAI.enabled = true;

        DataBank.Instance.MyStats.CutSceneDisplayed = true;
        Destroy(CutSceneCluster);

    }
}