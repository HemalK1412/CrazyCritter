using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField] Transform[] defaults;
    public GameObject[] cups;


    public int first, second;

    [SerializeField] float lerpmultiplier, NoofDays;

    private Vector3 firstCupPosition, secondCupPosition, median, perpendicular;
    private bool shufflestart;

    private void Start()
    {
        ResetPositions();
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {

            shufflestart = true;

            List<int> DefaultLength = new List<int>() { 0, 1, 2 };

            first = Random.Range(0, DefaultLength.Count);

            DefaultLength.Remove(first);


            second = Random.Range(0, DefaultLength.Count);

            firstCupPosition = cups[first].transform.position;

            secondCupPosition = cups[second].transform.position;

            median = firstCupPosition + (secondCupPosition - firstCupPosition) / 2;
        }

        if (shufflestart)
        {
            perpendicular = Vector3.Cross((secondCupPosition - firstCupPosition) / 2, Vector3.up).normalized;

            cups[first].transform.position = EvaluateSlerpPoints(cups[first].transform.position, secondCupPosition, median - perpendicular);

            cups[second].transform.position = EvaluateSlerpPoints(cups[second].transform.position, firstCupPosition, median + perpendicular);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(firstCupPosition, median);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(median, median + perpendicular);
    }


    private void ResetPositions()
    {
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = defaults[i].transform.position;
        }
    }

    Vector3 EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;


        
        return Vector3.Slerp(startRelativeCenter, endRelativeCenter, lerpmultiplier * Time.deltaTime) + center;
        
    }
    
}
