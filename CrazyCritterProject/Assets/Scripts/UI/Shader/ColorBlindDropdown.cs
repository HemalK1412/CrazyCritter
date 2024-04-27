using TMPro;
using UnityEngine;

public class ColorBlindDropdown : MonoBehaviour
{

    [SerializeField] public ColorBlindFilter colorBlindFilter;
    [SerializeField] DataBank dataBank;
    public TMP_Dropdown dropdown;
    public int MenuValue;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        dropdown.value = dataBank.MyStats.ColorBlindEnum;

        dataBank.MyStats.ColorBlindEnum = (int)colorBlindFilter.mode;
    }

    private void OnDropdownValueChanged(int value)
    {
        ColorBlindMode mode = (ColorBlindMode)value;

        dataBank.MyStats.ColorBlindEnum = dropdown.value;

        colorBlindFilter.mode = mode;
    }
}