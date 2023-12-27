using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] LevelPanel levelPanel;
    [SerializeField] SettingsPanel settingsPanel;
    [SerializeField] InventoryPanel inventoryPanel;
    [SerializeField] ShopPanel shopPanel;

    

    public void PlayButton()
    {
        levelPanel.Open();
    }

    public void ShopButton()
    {
        shopPanel.Open();   
    }

    public void SettingsButton()
    {
        settingsPanel.Open();
    }

    public void InventoryButton()
    {
        inventoryPanel.Open();
    }
}
