using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int gold;
    public int cristal;
    public int maxLevelIndex;
    public List<SerializableLevel> levels;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        gold = 0;
        cristal = 0;
        maxLevelIndex = 0;
        levels = new List<SerializableLevel>();
    }
}
