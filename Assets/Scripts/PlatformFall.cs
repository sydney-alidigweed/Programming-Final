using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    bool willFall = false;
    float currentTime;
    float waitTime = 0.5f;
    float destroyAfter = 2.0f;

    void Start()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        if (willFall == true)
        {
            if(currentTime > waitTime)
            {
                currentTime = currentTime - waitTime;
                PlatformWillFall();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && !willFall)
        {
            willFall = true;
        }
        else if (other.tag == "Ball" && willFall)
        {
            willFall = false;
        }
    }

    void PlatformWillFall()
    {

        if (currentTime > destroyAfter)
        {
            currentTime = currentTime - destroyAfter;
            Destroy(gameObject);
        }
    }
}
