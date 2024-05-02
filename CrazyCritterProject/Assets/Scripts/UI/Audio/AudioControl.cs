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

        MasterVolumeSlider.value = DataBank.Instance.MyStats.MasterVolume;
        Master.SetFloat("VolumeMaster", Mathf.Log10(MasterVolumeSlider.value) * 20);

        BackgroundVolumeSlider.value = DataBank.Instance.MyStats.BackGroundVolume;
        Master.SetFloat("VolumeBackground", Mathf.Log10(BackgroundVolumeSlider.value) * 20);

        SFXVolumeSlider.value = DataBank.Instance.MyStats.Sfx_volume;
        Master.SetFloat("VolumeSFX", Mathf.Log10(SFXVolumeSlider.value) * 20);
    }
    public void SetMasterVolume()
    {
        M_Volume = Mathf.Log10(MasterVolumeSlider.value) * 20;
        if (DataBank.Instance == null)
        {
            Debug.LogWarning("Can't set volume because DataBank is null");
            return;
        }
        DataBank.Instance.MyStats.MasterVolume = MasterVolumeSlider.value;
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
        DataBank.Instance.MyStats.BackGroundVolume = BackgroundVolumeSlider.value;
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
        DataBank.Instance.MyStats.Sfx_volume = SFXVolumeSlider.value;
        Master.SetFloat("VolumeSFX", DataBank.Instance.MyStats.Sfx_volume);
    }

}
