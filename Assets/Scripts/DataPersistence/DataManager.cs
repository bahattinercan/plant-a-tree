using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField]
    private string fileName;

    [SerializeField]
    private bool useEncryption;

    [HideInInspector]
    public GameData data;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    private bool isLoaded = false;

    public static DataManager instance { get; private set; }
    public bool IsLoaded { get => isLoaded; }

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

    private void Start()
    {
        print("data persistance start");
        this.dataHandler = new FileDataHandler(
            Application.persistentDataPath,
            fileName,
            useEncryption
        );
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        data = new GameData();
        
        var levels = Resources.Load<LevelListSO>("LevelList").levels;
        for (int i = 0; i < levels.Count; i++)
        {
            data.levels.Add(new SerializableLevel(id: i));
        }
        

    }

    public void LoadGame()
    {
        // load any saved data from a file using the data handler
        data = dataHandler.Load();

        // if no data can be loaded, initialize to a new game
        if (data == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        else
        {
            print("Data was found");            
            var levels = Resources.Load<LevelListSO>("LevelList").levels;
            print("level count " + levels.Count);
            print("gameData level count " + data.levels.Count);
            if (levels.Count > data.levels.Count)
            {
                for (int i = 0; i < levels.Count; i++)
                {
                    if (i >= data.levels.Count)
                    {
                        data.levels.Add(new SerializableLevel(i));
                    }
                }
            }
            
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(data);
        }
        isLoaded = true;
    }

    public void SaveGame()
    {
        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(data);
        }

        // save that data to a file using the data handler
        dataHandler.Save(data);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
