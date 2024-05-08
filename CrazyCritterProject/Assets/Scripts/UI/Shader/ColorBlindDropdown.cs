using TMPro;
using UnityEngine;

public class ColorBlindDropdown : MonoBehaviour
{

    [SerializeField] public ColorBlindFilter colorBlindFilter;
    public TMP_Dropdown dropdown;
    public int MenuValue;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("DataBank is null");
            return;
        }
        dropdown.value = DataBank.Instance.MyStats.ColorBlindEnum;

        DataBank.Instance.MyStats.ColorBlindEnum = (int)colorBlindFilter.mode;
    }

    private void OnDropdownValueChanged(int value)
    {
        ColorBlindMode mode = (ColorBlindMode)value;
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("DataBank is null");
            return;
        }
        DataBank.Instance.MyStats.ColorBlindEnum = dropdown.value;

        colorBlindFilter.mode = mode;
    }
}