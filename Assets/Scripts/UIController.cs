using UnityEngine;

public class UIController : MonoBehaviour
{
    private Transform winEndGamePanel;
    private Transform loseEndGamePanel;

    private void Start()
    {
        winEndGamePanel = GameObject.Find("WinEndGamePanel").transform;
        winEndGamePanel.gameObject.SetActive(false);
        loseEndGamePanel = GameObject.Find("LoseEndGamePanel").transform;
        loseEndGamePanel.gameObject.SetActive(false);
        GameManager.instance.OnGameFinished += GameManager_OnGameFinished;
    }

    private void GameManager_OnGameFinished(bool isFinished)
    {
        if (isFinished)
        {
            winEndGamePanel.gameObject.SetActive(true);
        }
        else
        {
            loseEndGamePanel.gameObject.SetActive(true);
        }
    }
}