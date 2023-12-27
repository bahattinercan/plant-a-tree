using UnityEngine;

public enum EPrefs
{
    musicVolume,
    sfxVolume,
}

public class PrefManager : MonoBehaviour
{
    // Singleton instance of the PrefabManager class
    public static PrefManager instance;

    private float musicVolume;
    private float sfxVolume;

    public float MusicVolume
    {
        get => musicVolume;
        set
        {
            PlayerPrefs.SetFloat("musicVolume", value);
            AudioManager.Instance.MusicVolume = value;
            musicVolume = value;
        }
    }
    public float SfxVolume
    {
        get => sfxVolume;
        set
        {
            PlayerPrefs.SetFloat("sfxVolume", value);
            AudioManager.Instance.SfxVolume = value;
            sfxVolume = value;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            Setup();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Setup()
    {
        // music volume
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicVolume = 1;
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        // sfx volume
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            sfxVolume = 1;
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        }
    }
}
