using UnityEngine;
using TMPro;

public class MiniGamestimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime;


    void FixedUpdate()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = ("Time: " + string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
