using UnityEngine;
using TMPro;

public class CasinoUI : MonoBehaviour
{
    public TextMeshProUGUI DayCountUIElem;
    public TextMeshProUGUI NutCountUIElem;

    public Canvas HUD;
    public GameObject BackStoryElem;

    [SerializeField] SaveManager saveManager;

    private void FixedUpdate()
    {
        DayCountUIElem.text = DataBank.Instance.MyStats.DayCount.ToString();
        NutCountUIElem.text = DataBank.Instance.MyStats.Nuts.ToString();
    }

    public void OnPressStart()
    {
        DataBank.Instance.MyStats.Backstory = true;
        saveManager.Save();
        Time.timeScale = 1.0f;

        BackStoryElem.SetActive(false);
        HUD.gameObject.SetActive(true);
    }
}
