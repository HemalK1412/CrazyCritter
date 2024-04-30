using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer Master;
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider BackgroundVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;

    float M_Volume;
    float BG_Volume;
    float SFX_Volume;

    private void Start()
    {
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("DataBank is null");
            return;
        }
        M_Volume = DataBank.Instance.MyStats.MasterVolume;
        Master.SetFloat("VolumeMaster", M_Volume);
        MasterVolumeSlider.value = M_Volume;

        BG_Volume = DataBank.Instance.MyStats.BackGroundVolume;
        Master.SetFloat("VolumeBackground", BG_Volume);
        BackgroundVolumeSlider.value = BG_Volume;

        SFX_Volume = DataBank.Instance.MyStats.Sfx_volume;
        Master.SetFloat("VolumeSFX", SFX_Volume);
        SFXVolumeSlider.value = SFX_Volume;
        
    }
    public void SetMasterVolume()
    {
        M_Volume = Mathf.Log10(MasterVolumeSlider.value) * 20;
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("Can't set volume because DataBank is null");
            return;
        }
        DataBank.Instance.MyStats.MasterVolume = M_Volume;
        Master.SetFloat("VolumeMaster", DataBank.Instance.MyStats.MasterVolume);
    }

    public void SetBackGroundVolume()
    {
        BG_Volume = Mathf.Log10(BackgroundVolumeSlider.value) * 20;
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("Can't set volume because DataBank is null");
            return;
        }
        DataBank.Instance.MyStats.BackGroundVolume = BG_Volume;
        Master.SetFloat("VolumeBackground", DataBank.Instance.MyStats.BackGroundVolume);
    }

    public void SetSFXVolume()
    {
        SFX_Volume = Mathf .Log10(SFXVolumeSlider.value) * 20;
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("Can't set volume because DataBank is null");
            return;
        }
        DataBank.Instance.MyStats.Sfx_volume = SFX_Volume;
        Master.SetFloat("VolumeSFX", DataBank.Instance.MyStats.Sfx_volume);
    }

}
