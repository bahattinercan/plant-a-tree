using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField]
    EndGamePanel endGamePanel;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    Animator scoreAnim;

    public static UIManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        endGamePanel.gameObject.SetActive(false);
        GameManager.instance.OnGameFinished += GameManager_OnGameFinished;
        scoreText.text = "0/" + GameManager.instance.scoreGoal;
    }

    public void AddScore()
    {
        GameManager.instance.score++;
        scoreText.text = GameManager.instance.score + "/" + GameManager.instance.scoreGoal;
        scoreAnim.Play("scoreText_score");
    }

    private void GameManager_OnGameFinished(bool isFinished)
    {
        int level = GameManager.instance.serializableLevel.id + 1;
        endGamePanel.Open(
            level: level,
            isWin: isFinished,
            seconds: 100,
            gold: isFinished ? DataCarrier.instance.levelSo.winGold : 0
        );
    }
}
