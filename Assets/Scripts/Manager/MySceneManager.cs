
using UnityEngine.SceneManagement;

public static class MySceneManager
{
    public enum SceneType
    {
        SplashScreen,
        MainMenu,
        Gameplay
    }

    public static void LoadScene(SceneType sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static bool IsThisScene(SceneType sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName.ToString();
    }
}
