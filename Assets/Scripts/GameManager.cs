using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action<bool> OnGameFinished;
    public event Action OnSuccessfulHit;
    public int level;
    public LevelSO levelSO;
    public int maxLevelNumber;

    public void Invoke_OnSuccessfulHit()
    {
        OnSuccessfulHit?.Invoke();
    }

    public int scoreGoal;
    public int score;

    private void Awake()
    {
        instance = this;
        level = PlayerPrefs.GetInt("currentLevel");
        Debug.Log(level);
        levelSO = Resources.Load<LevelListSO>("levelList").GetLevel(level);
        maxLevelNumber = Resources.Load<LevelListSO>("levelList").GetLevelNumber();
        scoreGoal = levelSO.scoreGoal;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void OnGameFinished_Invoke(bool isPlayerWin)
    {
        Time.timeScale = 0;
        OnGameFinished?.Invoke(isPlayerWin);
        // Oyun kazanýlmýþsa yeni level açýlýr
        if (isPlayerWin && PlayerPrefs.GetInt("level") == level)
        {
            // eðer oyuncu son levele geldiyse level açýlmaz
            if (level != maxLevelNumber)
            {
                PlayerPrefs.SetInt("level", level + 1);
            }                
        }
            
           
        
    }
}