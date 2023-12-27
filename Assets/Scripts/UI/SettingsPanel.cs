using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider audioSlider;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume); 
        audioSlider.onValueChanged.AddListener(SetAudioVolume);
    }

    public void Open()
    {
        musicSlider.value = PrefManager.instance.MusicVolume;       
        audioSlider.value = PrefManager.instance.SfxVolume;  
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);

    }

    public void SetMusicVolume(float value)
    {
        PrefManager.instance.MusicVolume = value;
    }

    public void SetAudioVolume(float value)
    {
        PrefManager.instance.SfxVolume = value;
    }

    public void AchivementButton()
    {
        
    }

    public void VibrationButton()
    {

    }

    public void NoAdsButton()
    {

    }

    public void GooglePlayButton()
    {

    }
}
