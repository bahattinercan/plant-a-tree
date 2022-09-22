using UnityEngine;
using TMPro;
public class LevelText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Level " + GameManager.instance.level;
    }
}
