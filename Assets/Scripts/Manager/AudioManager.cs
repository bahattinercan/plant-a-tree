using UnityEngine;
using System.Collections;

public enum SfxType
{
    start,
    win,
    lose,
    throwTree,
    treeHit,
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private AudioSource start;

    [SerializeField]
    private AudioSource win;

    [SerializeField]
    private AudioSource lose;


    [SerializeField]
    private AudioSource throwTree;

    [SerializeField]
    private AudioSource treeHit;


    private bool canPlayMusic = true;
    private bool canPlaySfx = true;
    private float musicVolume = 1;
    private float sfxVolume = 1;

    [SerializeField]
    private AudioClip gameMusic;

    [SerializeField]
    private AudioClip mainMenuMusic;
    public static AudioManager Instance
    {
        get => instance;
    }
    public float MusicVolume
    {
        get => musicVolume;
        set
        {
            return;
            music.volume = value;
            musicVolume = value;
        }
    }
    public float SfxVolume
    {
        get => sfxVolume;
        set
        {
            return;
            start.volume = value;
            win.volume = value;
            lose.volume = value;
           throwTree.volume = value;
            treeHit.volume = value;
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
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        musicVolume = PrefManager.instance.MusicVolume;
        sfxVolume = PrefManager.instance.SfxVolume;
    }

    public void StartMainMenuMusic()
    {
        SetMusic(true, mainMenuMusic);
    }

    public void StartGameMusic()
    {
        StartCoroutine(PlayGameMusic());
    }

    public IEnumerator PlayGameMusic()
    {
        SetMusic(false, null);
        PlaySFX(SfxType.start);
        yield return new WaitForSeconds(3f);
        SetMusic(true, gameMusic);
    }

    public void PlaySFX(SfxType type)
    {
        if (!canPlaySfx)
            return;

        AudioSource source = null;

        switch (type)
        {
            case SfxType.start:
                source = start;
                break;
            case SfxType.win:
                source = win;
                break;
            case SfxType.lose:
                source =lose;
                break;
            case SfxType.throwTree:
                source = throwTree;
                break;
            case SfxType.treeHit:
                    source = treeHit;
                break;
        }
        if (source == null)
            return;
        source.Play();
        source.pitch = Random.Range(.9f, 1.1f);
        source.volume = Random.Range(.9f * sfxVolume, 1f * sfxVolume);
    }

    public void StopSFX(SfxType type)
    {
        AudioSource source = null;

        switch (type)
        {
            case SfxType.start:
                source = start;
                break;
            case SfxType.win:
                source = win;
                break;
            case SfxType.lose:
                source = lose;
                break;
            case SfxType.throwTree:
                source = throwTree;
                break;
            case SfxType.treeHit:
                source = treeHit;
                break;
        }
        if (source == null)
            return;
        source.Stop();
    }

    public void SetVolumeSFX(SfxType type, float value)
    {
        AudioSource source = null;

        switch (type)
        {
            case SfxType.start:
                source = start;
                break;
            case SfxType.win:
                source = win;
                break;
            case SfxType.lose:
                source = lose;
                break;
            case SfxType.throwTree:
                source = throwTree;
                break;
            case SfxType.treeHit:
                source = treeHit;
                break;
        }
        if (source == null)
            return;
        source.volume = value;
    }

    public void SetMusic(bool canPlay, AudioClip audioClip)
    {
        music.volume = musicVolume;
        canPlayMusic = canPlay;
        music.clip = audioClip;
        if (canPlayMusic)
            music.Play();
        else
            music.Stop();
    }

    public void StopAll()
    {
        music.Stop();
        start.Stop();
        win.Stop();
        lose.Stop();
        throwTree.Stop();
        treeHit.Stop();
    }
}
