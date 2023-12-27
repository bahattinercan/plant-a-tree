using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        MySceneManager.RestartScene();
    }
}