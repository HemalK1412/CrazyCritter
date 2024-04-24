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

    private void Awake()
    {

    }
    public void SetMasterVolume()
    {
        float M_Volume = Mathf.Log10(MasterVolumeSlider.value) * 20;
        dataBank.MyStats.MasterVolume = M_Volume;
        Master.SetFloat("VolumeMaster", dataBank.MyStats.MasterVolume);

    }

    public void SetBackGroundVolume()
    {
        float BG_Volume = Mathf.Log10(BackgroundVolumeSlider.value) * 20;
        dataBank.MyStats.BackGroundVolume = BG_Volume;
        Master.SetFloat("VolumeBackground", dataBank.MyStats.BackGroundVolume);

    }

    public void SetSFXVolume()
    {
        float SFX_Volume = Mathf .Log10(SFXVolumeSlider.value) * 20;
        dataBank.MyStats.Sfx_volume = SFX_Volume;
        Master.SetFloat("VolumeSFX", dataBank.MyStats.Sfx_volume);
    }

}
