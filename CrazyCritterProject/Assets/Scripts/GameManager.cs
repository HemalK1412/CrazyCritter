
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject p_player;

    [SerializeField] int gm_DayoftheWeek;

    [SerializeField] int gm_Nuts;

    [SerializeField] float[] gm_position;

    public TMP_Text Daycount;
    public TMP_Text Nuts;
    public TMP_Text Position;

    public void Start()
    {
        float[] gm_position = new float[3];
        gm_position[1] = p_player.transform.position.x;
        gm_position[2] = p_player.transform.position.y;
        gm_position[3] = p_player.transform.position.z;
    }
    public void SaveData()
    {
        
        PlayerPrefs.SetInt("DayCount", gm_DayoftheWeek);

        PlayerPrefs.SetInt("Nuts", gm_Nuts);

        PlayerPrefs.SetFloat("gm_positionX", gm_position[1]);
        PlayerPrefs.SetFloat("gm_positionY", gm_position[2]);
        PlayerPrefs.SetFloat("gm_positionZ", gm_position[3]);


    }

    public void LoadData()
    {
        Daycount.text = PlayerPrefs.GetInt("DayCount").ToString();
        Nuts.text = PlayerPrefs.GetInt("Nuts").ToString();

        Position.text = (PlayerPrefs.GetFloat("gm_positionX").ToString() + "," + PlayerPrefs.GetFloat("gm_positionY").ToString() + "," + PlayerPrefs.GetFloat("gm_positionZ").ToString());
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
