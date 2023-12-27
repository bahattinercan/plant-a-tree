using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Level")]
public class LevelSO : ScriptableObject
{
    public int levelIndex;
    public float worldSpeedMultiplier = 1f;
    public float treeSpeedMultiplier = 1f;
    public float treeScaleMultiplier = 1f;
    public int scoreGoal = 8;
    public bool startReverseWorld = false;
    public bool willWorldReverseWhenHitSuccessful = false;
    public int winGold = 5;   
   
}
