using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action<bool> OnGameFinished;

    public event Action OnSuccessfulHit;

    public int levelIndex;
    public LevelSO levelSO;
    public SerializableLevel serializableLevel;
    public Timer timer;

    public void Invoke_OnSuccessfulHit()
    {
        OnSuccessfulHit?.Invoke();
    }

    public int scoreGoal;
    public int score;

    private void Awake()
    {
        instance = this;

        levelSO = DataCarrier.instance.levelSo;
        serializableLevel = DataCarrier.instance.serializableLevel;
        levelIndex = serializableLevel.id;
        scoreGoal = levelSO.scoreGoal;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    public void OnGameFinished_Invoke(bool isPlayerWin)
    {
        print("isPlayerWin "+isPlayerWin);
     
        Time.timeScale = 0;
        // Oyun kazanýlmýþsa yeni level açýlýr
        if (isPlayerWin)
        {
            DataManager.instance.data.gold += levelSO.winGold;
            if (levelIndex+1 > DataManager.instance.data.maxLevelIndex)
            {
                DataManager.instance.data.maxLevelIndex = levelIndex + 1;
            }
        }
        OnGameFinished?.Invoke(isPlayerWin);
    }
}
