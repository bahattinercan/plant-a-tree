using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum clipTypes
    {
        win,
        lose,
        hit
    }

    private AudioSource audioSource;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip hitClip;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(clipTypes clipType)
    {
        switch (clipType)
        {
            case clipTypes.win:
                audioSource.PlayOneShot(winClip);
                break;
            case clipTypes.lose:
                audioSource.PlayOneShot(loseClip);
                break;
            case clipTypes.hit:
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(hitClip);
                break;
        }
       
    }
}