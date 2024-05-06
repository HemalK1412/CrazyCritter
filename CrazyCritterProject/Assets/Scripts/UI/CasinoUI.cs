using UnityEngine;
using TMPro;

public class CasinoUI : MonoBehaviour
{
    public TextMeshProUGUI DayCountUIElem;
    public TextMeshProUGUI NutCountUIElem;

    private void FixedUpdate()
    {
        DayCountUIElem.text = DataBank.Instance.MyStats.DayCount.ToString();
        NutCountUIElem.text = DataBank.Instance.MyStats.Nuts.ToString();
    }
}
