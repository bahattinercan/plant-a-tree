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
        // Oyun kazan�lm��sa yeni level a��l�r
        if (isPlayerWin && PlayerPrefs.GetInt("level") == level)
        {
            // e�er oyuncu son levele geldiyse level a��lmaz
            if (level != maxLevelNumber)
            {
                PlayerPrefs.SetInt("level", level + 1);
            }                
        }
            
           
        
    }
}