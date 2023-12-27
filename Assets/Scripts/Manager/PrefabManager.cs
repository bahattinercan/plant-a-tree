using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager instance;
    public LevelListSO levelList;
    public GameObject levelButton;

    public Sprite starSprite;
    public Sprite emptyStarSprite;

    public static PrefabManager Instance
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
