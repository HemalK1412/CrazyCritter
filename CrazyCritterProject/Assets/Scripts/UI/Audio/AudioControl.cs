using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer Master;
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider BackgroundVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    [SerializeField] DataBank dataBank;

    float M_Volume;
    float BG_Volume;
    float SFX_Volume;

    private void Awake()
    {
        dataBank = GameObject.Find("DataBank").gameObject.GetComponent<DataBank>();
        
        /*
        M_Volume = dataBank.MyStats.MasterVolume;
        Master.SetFloat("VolumeMaster", M_Volume);
        MasterVolumeSlider.value = M_Volume;

        BG_Volume = dataBank.MyStats.BackGroundVolume;
        Master.SetFloat("VolumeBackground", BG_Volume);
        BackgroundVolumeSlider.value = BG_Volume;

        SFX_Volume = dataBank.MyStats.Sfx_volume;
        Master.SetFloat("VolumeSFX", SFX_Volume);
        SFXVolumeSlider.value = SFX_Volume;
        */
    }
    public void SetMasterVolume()
    {
        M_Volume = Mathf.Log10(MasterVolumeSlider.value) * 20;
        dataBank.MyStats.MasterVolume = M_Volume;
        Master.SetFloat("VolumeMaster", dataBank.MyStats.MasterVolume);

    }

    public void SetBackGroundVolume()
    {
        BG_Volume = Mathf.Log10(BackgroundVolumeSlider.value) * 20;
        dataBank.MyStats.BackGroundVolume = BG_Volume;
        Master.SetFloat("VolumeBackground", dataBank.MyStats.BackGroundVolume);

    }

    public void SetSFXVolume()
    {
        SFX_Volume = Mathf .Log10(SFXVolumeSlider.value) * 20;
        dataBank.MyStats.Sfx_volume = SFX_Volume;
        Master.SetFloat("VolumeSFX", dataBank.MyStats.Sfx_volume);
    }

}
