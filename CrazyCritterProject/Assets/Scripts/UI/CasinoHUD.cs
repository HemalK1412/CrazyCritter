using UnityEngine;
using TMPro;

public class CasinoHUD : MonoBehaviour
{
    public TextMeshProUGUI DayCountUIElem;
    public TextMeshProUGUI NutCountUIElem;

    private void FixedUpdate()
    {
        DayCountUIElem.text = $"DayCount: {DataBank.Instance.MyStats.DayCount}";
        NutCountUIElem.text = $"NutCount: {DataBank.Instance.MyStats.Nuts}";
    }
}
