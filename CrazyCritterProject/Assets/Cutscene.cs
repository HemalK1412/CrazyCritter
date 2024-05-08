using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CutScene : MonoBehaviour
{
    public Transform[] Teleports;
    public Transform[] Lerps;
    public float lerpDuration = 3f;

    private void Awake()
    {
    }
    private void Start()
    {

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


        DataBank.Instance.MyStats.CutSceneDisplayed = true;

    }
}