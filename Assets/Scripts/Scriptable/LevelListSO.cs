using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/LevelList")]
public class LevelListSO : ScriptableObject
{
    public List<LevelSO> levels;

    public LevelSO GetLevel(int level)
    {
        return levels[level - 1];
    }

    public int GetLevelNumber()
    {
        return levels.Count;
    }
}