using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    float timer;
    float waitTime = 0.2f;

    bool ballOnPlatform = false;

    [SerializeField] GameObject platform;
    [SerializeField] GameObject diamond;

    void Start()
    {
        SpawnPlatform();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            if (ballOnPlatform == true)
            {
                timer = timer - waitTime;
                SpawnPlatform();
            }
        }
    }

    void SpawnPlatform()
    {
        transform.position = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        Vector3 offset = new Vector3(1, 0, 0) + transform.position;
        Instantiate(platform, offset, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && !ballOnPlatform)
        {
            ballOnPlatform = true;
        }
        else if (other.tag == "Ball" && ballOnPlatform)
        {
            ballOnPlatform = false;
        }
    }
}
