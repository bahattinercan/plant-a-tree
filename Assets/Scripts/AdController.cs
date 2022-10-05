using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class AdController : MonoBehaviour
{
    public static AdController Instance;
    private int currentGame;
    [SerializeField] private int neededGameForAd;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void GameFinished()
    {
        currentGame++;
        if(currentGame>=neededGameForAd)
        {
            // open ad
            currentGame = 0;
        }
    }
}
