using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform[] weapons;
    private float rotateSpeed = 100f;

    private void Start()
    {
        weapons = new Transform[transform.childCount];
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }
    }
}