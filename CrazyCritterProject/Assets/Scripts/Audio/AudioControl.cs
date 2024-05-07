using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer Master;
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider BackgroundVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;

    public float M_Volume;
    public float BG_Volume;
    public float SFX_Volume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("p_PrefsMasterVolume"))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }


        if (PlayerPrefs.HasKey("p_PrefsbackGroundVolume"))
        {
            LoadBackgroundVolume();
        }
        else
        {
            SetBackgroundVolume();
        }
        
        
        if (PlayerPrefs.HasKey("p_PrefsMasterVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }


    public void SetMasterVolume()
    {
        M_Volume = MasterVolumeSlider.value;
        Master.SetFloat("VolumeMaster", Mathf.Log10(M_Volume)*20f);
        PlayerPrefs.SetFloat("p_PrefsMasterVolume", M_Volume);

    }

    public void LoadMasterVolume()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("p_PrefsMasterVolume");
        SetMasterVolume();
    }

    public void SetBackgroundVolume()
    {
        BG_Volume = BackgroundVolumeSlider.value;
        Master.SetFloat("VolumeBackground", Mathf.Log10(BG_Volume) * 20f);
        PlayerPrefs.SetFloat("p_PrefsBackgroundVolume", BG_Volume);

    }

    public void LoadBackgroundVolume()
    {
        BackgroundVolumeSlider.value = PlayerPrefs.GetFloat("p_PrefsBackgroundVolume");
        SetBackgroundVolume();
    }
    

    public void SetSFXVolume()
    {
        SFX_Volume = SFXVolumeSlider.value;
        Master.SetFloat("VolumeSFX", Mathf.Log10(SFX_Volume) * 20f);
        PlayerPrefs.SetFloat("p_PrefsSFXVolume", SFX_Volume);

    }

    public void LoadSFXVolume()
    {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("p_PrefsSFXVolume");
        SetSFXVolume();
    }



    /*  This is the previous script using the Save manager using the Binary formatter.
     *  
     *  
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
    */

}
