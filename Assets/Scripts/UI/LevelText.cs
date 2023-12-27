using TMPro;
using UnityEngine;
public class LevelText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Level " + GameManager.instance.levelIndex;
    }
}
