using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{

    [SerializeField] Transform[] defaults;
    public GameObject[] cups;

    public int NoofShuffles = 3;
    public int first;
    public int second;

    [SerializeField] int NoofDays;
    [SerializeField] float lerpmultiplier;
    [SerializeField] float ShuffleDuration;

    private Vector3 firstCupPosition;
    private Vector3 secondCupPosition;
    private Vector3 midpoint;
    private Vector3 perpendicular;


    private void Start()
    {
        ResetPositions();
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {


            //CupstoShuffle();

            StartCoroutine(BaseShuffle());

            //StartCoroutine(ShuffleOnce());
            //midpoint = firstCupPosition + (secondCupPosition - firstCupPosition) / 2;
        }
        
        /*
        if (shufflestart)
        {
            
            perpendicular = Vector3.Cross((secondCupPosition - firstCupPosition) / 2, Vector3.up).normalized;

            cups[first].transform.position = EvaluateSlerpPoints(cups[first].transform.position, secondCupPosition, median - perpendicular);

            cups[second].transform.position = EvaluateSlerpPoints(cups[second].transform.position, firstCupPosition, median + perpendicular);
            
        }
        */
    }


    private void ResetPositions()
    {
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = defaults[i].transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(firstCupPosition, midpoint);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(midpoint, midpoint + perpendicular);
    }


    private void CupstoShuffle()
    {
        List<int> DefaultLength = new List<int>() { 0, 1, 2 };

        first = DefaultLength[Random.Range(0, DefaultLength.Count)];
        DefaultLength.Remove(first);
        second = DefaultLength[Random.Range(0, DefaultLength.Count)];

        firstCupPosition = cups[first].transform.position;
        secondCupPosition = cups[second].transform.position;

    }


    Vector3 EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center, float t)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;
        
        return Vector3.Slerp(startRelativeCenter, endRelativeCenter, t) + center;
    }
    
    IEnumerator ShuffleOnce()
    {
        CupstoShuffle();

        float t = 0;

        midpoint = firstCupPosition + (secondCupPosition - firstCupPosition) / 2;
        perpendicular = Vector3.Cross((secondCupPosition - firstCupPosition) / 2, Vector3.up).normalized;

        Vector3 cup1 = cups[first].transform.position, cup2 = cups[second].transform.position;

        while (t <= ShuffleDuration)
        {
            t += Time.deltaTime;
            Debug.Log("t = " + t/ShuffleDuration);
            
            cups[first].transform.position = EvaluateSlerpPoints(cup1, secondCupPosition, midpoint - perpendicular, t/ShuffleDuration);
            cups[second].transform.position = EvaluateSlerpPoints(cup2, firstCupPosition, midpoint + perpendicular, t/ShuffleDuration);
            
            /*
            cups[first].transform.position = Vector3.Lerp(cup1, secondCupPosition, t / ShuffleDuration);
            cups[second].transform.position = Vector3.Lerp(cup2, firstCupPosition, t / ShuffleDuration);
            */
            //yield return new WaitForSeconds (Time.deltaTime);
            yield return null;
        }
        /*
        cups[first].transform.position = EvaluateSlerpPoints(cups[first].transform.position, secondCupPosition, midpoint - perpendicular, 1);

        cups[second].transform.position = EvaluateSlerpPoints(cups[second].transform.position, firstCupPosition, midpoint + perpendicular, 1);
        */
    }

    IEnumerator BaseShuffle()
    {
        for (int i = 0; i < NoofShuffles; i++)
        {
            StartCoroutine(ShuffleOnce());
            yield return new WaitForSeconds(ShuffleDuration);
        }
    }

}
