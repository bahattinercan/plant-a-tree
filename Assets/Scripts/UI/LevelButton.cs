using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI textUI;

    [SerializeField]
    private Button button;

    public void Setup(string text, bool isActive, UnityAction action)
    {
        this.textUI.text = text;
        button.interactable = isActive;
        if (isActive)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);
        }
    }
}
