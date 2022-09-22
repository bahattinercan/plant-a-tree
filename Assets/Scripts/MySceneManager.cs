
using UnityEngine.SceneManagement;
public static class MySceneManager
{
    public enum SceneNames
    {
        SplashScreen,
        MainMenu,
        Gameplay
    }

    public static void LoadScene(SceneNames sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static bool IsThisScene(SceneNames sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName.ToString();
    }
}
