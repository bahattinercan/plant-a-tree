using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotator : MonoBehaviour
{
    public float speed = -3;

    private void Update()
    {
        transform.Rotate(0, speed, 0);
    }

    public void ReverseRotate()
    {
        speed *= -1;
    }
}
