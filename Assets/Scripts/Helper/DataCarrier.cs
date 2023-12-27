using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataCarrier : MonoBehaviour
{
    public static DataCarrier instance { get; private set; }

    public LevelSO levelSo;
    public SerializableLevel serializableLevel;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SelectLevel(int levelIndex)
    {
       levelSo = PrefabManager.Instance.levelList.levels[levelIndex];
      serializableLevel = DataManager.instance.data.levels[levelIndex];
        
    }
    
}
