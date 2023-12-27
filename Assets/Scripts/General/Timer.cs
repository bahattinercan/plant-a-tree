using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public bool isWorking = true;
    public float seconds = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isWorking == false)
            return;
        seconds += Time.deltaTime;
    }
}
