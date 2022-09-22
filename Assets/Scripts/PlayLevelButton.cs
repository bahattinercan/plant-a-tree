using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayLevelButton : MonoBehaviour
{
    [SerializeField] private int level = 1;
    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = level.ToString();
        if (PlayerPrefs.GetInt("level") >= level)
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("currentLevel", level);
                MySceneManager.LoadScene(MySceneManager.SceneNames.Gameplay);
            });
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }        
    }
}