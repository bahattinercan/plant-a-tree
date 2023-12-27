using UnityEngine;
using System.Collections.Generic;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] Transform grid;
    bool isSetupNeed = true;

    private void Setup()
    {
        List<SerializableLevel> levels = DataManager.instance.data.levels;
        List<LevelSO> levelSOs = PrefabManager.Instance.levelList.levels;
        GameObject buttonPrefab = PrefabManager.Instance.levelButton;
        int maxLevelIndex = DataManager.instance.data.maxLevelIndex;

        for (int i = 0; i < DataManager.instance.data.levels.Count; i++)
        {
            var serializableLevel = levels[i];
            var levelSo= levelSOs[i];   
            LevelButton levelButton = Instantiate(buttonPrefab, grid).GetComponent<LevelButton>();
            levelButton.Setup(text: $"{i+1}", isActive: i<=maxLevelIndex, action: () =>
            {
                DataCarrier.instance.levelSo = levelSo;
                DataCarrier.instance.serializableLevel = serializableLevel;
                MySceneManager.LoadScene(MySceneManager.SceneType.Gameplay);
            });
        }

        isSetupNeed = false;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        if (isSetupNeed)
        {
            Setup();
        }

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
