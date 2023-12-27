using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1f;
        MySceneManager.LoadScene(MySceneManager.SceneType.MainMenu);
    }
}