using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelList")]
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