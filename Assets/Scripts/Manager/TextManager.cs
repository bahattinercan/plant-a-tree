using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;

    public static TextManager Instance
    {
        get => instance;
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
}
