using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("currentLevel", GameManager.instance.levelIndex + 1);
        MySceneManager.RestartScene();
    }
}