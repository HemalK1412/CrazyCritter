using UnityEngine;

public class ColorBlind : MonoBehaviour
{
    public FilterMode mode = FilterMode.Normal;
    private FilterMode previousMode = FilterMode.Normal;

    [SerializeField] private Material shaderMaterial;

    private static Color[,] RGB =
    {
        {new Color(1f,0f,0f), new Color(0f, 1f, 0f), new Color(0f, 1f, 0f)}, // Normal
        {new Color(0.56667f,0.43333f,0f), new Color(0.55833f, 0.44167f, 0f), new Color(0f, 0.24167f, 0.75833f)}, // Protanopia
        {new Color(0.81667f,0.18333f,0f), new Color(0.33333f, 0.66667f, 0f), new Color(0f, 0.12500f, 0.87500f)}, // Protanomaly
        {new Color(0.62500f,0.32500f,0f), new Color(0.70000f, 0.30000f, 0f), new Color(0f, 0.30000f, 0.70000f)}, // Dueteranopia
        {new Color(0.80000f,0.20000f,0f), new Color(0.25833f, 0.74167f, 0f), new Color(0f, 0.14167f, 0.85833f)}, // Deuteranomaly
        {new Color(0.95000f,0.05000f,0f), new Color(0f, 0.43333f, 0.56667f), new Color(0f, 0.47500f, 0.52500f)}, // Tritanopia
        {new Color(0.96667f,0.03333f,0f), new Color(0f, 0.73333f, 0.26667f), new Color(0f, 0.18333f, 0.81667f)}, // Tritanomaly
        {new Color(0.29900f,0.58700f,0.11400f), new Color(0.29900f, 0.58700f, 0.11400f), new Color(0.29900f, 0.58700f, 0.11400f)}, // Achromatopsia
        {new Color(0.61800f,0.32000f,0.06200f), new Color(0.16300f, 0.77500f, 0.06200f), new Color(0.16300f, 0.32000f, 0.51600f)}  // Achromatomaly
    };

    private void Awake()
    {
        shaderMaterial = new Material(Shader.Find("ColorFilter"));
        shaderMaterial.SetColor("RV", RGB[0, 0]);
        shaderMaterial.SetColor("GV", RGB[0, 1]);
        shaderMaterial.SetColor("BV", RGB[0, 2]);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(mode == FilterMode.Normal)
        {
            Graphics.Blit(source, destination);
            return;
        }
        if (mode != previousMode)
        {
            shaderMaterial.SetColor("RV", RGB[(int)mode, 0]);
            shaderMaterial.SetColor("GV", RGB[(int)mode, 1]);
            shaderMaterial.SetColor("BV", RGB[(int)mode, 2]);
            previousMode = mode;
        }

        Graphics.Blit(source, destination, shaderMaterial);
    }
}

public enum FilterMode
{
    Normal = 0,
    Protanopia = 1,
    Protanomaly = 2,
    Dueteranopia = 3,
    Deuteranomaly = 4,
    Tritanopia = 5,
    Tritanomaly = 6,
    Achromatopsia = 7,
    Achromatomaly = 8,
}


// The Color matrix came from this website https://web.archive.org/web/20081014161121/http://www.colorjack.com/labs/colormatrix/

/*
 {Normal:{ R:[100, 0, 0], G:[0, 100, 0], B:[0, 100, 0]},
 Protanopia:{ R:[56.667, 43.333, 0], G:[55.833, 44.167, 0], B:[0, 24.167, 75.833]},
 Protanomaly:{ R:[81.667, 18.333, 0], G:[33.333, 66.667, 0], B:[0, 12.5, 87.5]},
 Deuteranopia:{ R:[62.5, 37.5, 0], G:[70, 30, 0], B:[0, 30, 70]},
 Deuteranomaly:{ R:[80, 20, 0], G:[25.833, 74.167, 0], B:[0, 14.167, 85.833]},
 Tritanopia:{ R:[95, 5, 0], G:[0, 43.333, 56.667], B:[0, 47.5, 52.5]},
 Tritanomaly:{ R:[96.667, 3.333, 0], G:[0, 73.333, 26.667], B:[0, 18.333, 81.667]},
 Achromatopsia:{ R:[29.9, 58.7, 11.4], G:[29.9, 58.7, 11.4], B:[29.9, 58.7, 11.4]},
 Achromatomaly:{ R:[61.8, 32, 6.2], G:[16.3, 77.5, 6.2], B:[16.3, 32.0, 51.6]}
*/

/* 
 * This matrix is normalized for a Range maximum stat of 100. 
 * And the game has a Range Maximum of 1 so we just divide these values by 100
 */


/*
public class ColorBlindFilterChanger : MonoBehaviour
{
    public ColorBlindFilters colorBlindFilters;
    public int filterModeIndex;

    private void Start()
    {
        if (colorBlindFilters == null) { Debug.LogError("ColorBlindFilters component not found!"); return; }

        SetFilterMode((FilterMode)filterModeIndex);
    }

    public void SetFilterMode(FilterMode filterMode) { colorBlindFilters.mode = filterMode; }

    public void SetFilterMode(int filterModeIndex)
    {
        if (filterModeIndex < 0 || filterModeIndex >= System.Enum.GetNames(typeof(FilterMode)).Length) { Debug.LogError("Invalid filter mode index!"); return; }

        SetFilterMode((FilterMode)filterModeIndex);
    }
}
*/