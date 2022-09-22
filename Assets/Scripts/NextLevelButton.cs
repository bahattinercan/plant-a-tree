using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("currentLevel", GameManager.instance.level + 1);
        MySceneManager.RestartScene();
    }
}