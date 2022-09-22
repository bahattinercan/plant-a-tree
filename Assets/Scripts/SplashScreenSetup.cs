using UnityEngine;

public class SplashScreenSetup : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
    }
}