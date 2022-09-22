using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject
{
    public float worldSpeedMultiplier = 1f;
    public float treeSpeedMultiplier = 1f;
    public float treeScaleMultiplier = 1f;
    public int scoreGoal = 8;
    public bool startReverseWorld=false;
    public bool willWorldReverseWhenHitSuccessful=false;
}
