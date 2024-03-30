using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class Shuffle : MonoBehaviour
{
    [SerializeField] Transform[] defaults;
    [SerializeField] float lerpmultiplier;
    public GameObject[] cups;


    // To be grabbed form the GameManager(SaveSyatem)
    public int NoofDays;
    public int first, second;


    private Vector3 firstCupPosition, secondCupPosition;
    private bool shufflestart;
    int[] DefaultLength;

    Vector3 median, perpendicular;
    
    private void Start()
    {
        ResetPositions();
        //List<int> DefaultLength = GenerateIntegerList(0, defaults.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {

            //List<int> Locations = ShuffleList(DefaultLength);

            /*
            for (int j = 0; j < NoofDays; j++)
            {
                for(int k = 0;k < defaults.Length; k++)
                {
                    cups[k].transform.position = Vector3.Lerp(cups[k].transform.position, defaults[j].transform.position, lerpmultiplier);

                    cups[j].transform.position = Vector3.Lerp(cups[j].transform.position, defaults[k].transform.position, lerpmultiplier);
                }

            }
            */

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


    /*
    public List<int> ShuffleList(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }
    public List<int> GenerateIntegerList(int min, int max)
    {
        List<int> list = new List<int>();
        for (int i = min; i <= max; i++)
        {
            list.Add(i);
        }
        return list;
    }
    */
    Vector3 EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;


        
        return Vector3.Slerp(startRelativeCenter, endRelativeCenter, lerpmultiplier * Time.deltaTime) + center;
        
    }
    
}
