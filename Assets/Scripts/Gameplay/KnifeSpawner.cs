using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject knifePrefab;

    public void SpawnKnife()
    {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        go.transform.SetParent(spawnPoint);
    }
}