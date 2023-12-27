
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Resources")]
public class GameResourcesSO : ScriptableObject
{
    public LevelListSO levelList;
    public GameObject levelButton;

    public Sprite starSprite;
    public Sprite emptyStarSprite;
}
