using UnityEngine;

public class Wood : MonoBehaviour
{
    public float speed = -3;    
    private void Start()
    {
        if (!MySceneManager.IsThisScene(MySceneManager.SceneNames.SplashScreen))
        {
            speed *= GameManager.instance.levelSO.worldSpeedMultiplier;
            if (GameManager.instance.levelSO.startReverseWorld)
            {
                ReverseRotate();
            }
        }            
    }

    private void Update()
    {
        transform.Rotate(0, speed, 0);
    }

    public void ReverseRotate()
    {
        speed *= -1;
    }
}