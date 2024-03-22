using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class Shuffle : MonoBehaviour
{
    [SerializeField] Transform[] defaults;
    [SerializeField] float lerpmultiplier;
    public GameObject[] cups;

    
    
    GameManager2 gameManager;
    int[] DefaultLength;
    
    private void Start()
    {
        ResetPositions();
        List<int> DefaultLength = GenerateIntegerList(0, defaults.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            
            //List<int> Locations = ShuffleList(DefaultLength);

            for (int j = 0; j < gameManager.NoofDays; j++)
            {
                for(int k = 0;k < defaults.Length; k++)
                {
                    cups[k].transform.position = Vector3.Lerp(cups[k].transform.position, defaults[j].transform.position, lerpmultiplier);

                    cups[j].transform.position = Vector3.Lerp(cups[j].transform.position, defaults[k].transform.position, lerpmultiplier);
                }

            }

            /*
            int first = Random.Range(0, defaults.Length);

            int second = Random.Range(0, defaults.Length);
            
            cups[first].transform.position = Vector3.Lerp(cups[first].transform.position, defaults[first].transform.position, lerpmultiplier);

            cups[second].transform.position = Vector3.Lerp(cups[second].transform.position, defaults[second].transform.position, lerpmultiplier);
            */

        }

    }

    private void ResetPositions()
    {
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].transform.position = defaults[i].transform.position;
        }
    }



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
}
