using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI titleText;

    [SerializeField]
    TextMeshProUGUI levelText;

    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    TextMeshProUGUI goldText;

    [SerializeField]
    Button nextLevelButton;

    [SerializeField]
    List<Image> stars;

    public void Open(int level, bool isWin, float seconds, int gold)
    {
        
        levelText.text = $"Level {level}";
        goldText.text = $"{gold}";
        SetTime(seconds);
        if (isWin)
        {
            titleText.text = "Win!";
            foreach (var item in stars)
            {
                item.sprite = PrefabManager.Instance.starSprite;
            }
            // if has level
            if (
                PrefabManager.Instance.levelList.levels.Any(
                    (e) =>
                    {
                        return e.levelIndex == GameManager.instance.levelIndex + 1;
                    }
                )
            )
            {
                nextLevelButton.interactable = true;
            }
        }
        else
        {
            titleText.text = "Lose!";
            foreach (var item in stars)
            {
                item.sprite = PrefabManager.Instance.emptyStarSprite;
            }
            nextLevelButton.interactable = false;
        }
        gameObject.SetActive(true);
    }

    private void SetTime(float fullSeconds)
    {
        int minutes = Mathf.FloorToInt(fullSeconds / 60);
        int seconds = Mathf.FloorToInt(fullSeconds % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1;
        DataCarrier.instance.SelectLevel(GameManager.instance.levelIndex + 1);     
        MySceneManager.RestartScene();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        MySceneManager.RestartScene();
    }

    public void MainMenuButton()
    {
        MySceneManager.LoadScene(MySceneManager.SceneType.MainMenu);
    }
}
