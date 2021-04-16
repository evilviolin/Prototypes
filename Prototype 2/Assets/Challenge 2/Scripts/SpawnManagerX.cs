using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float timer = 2;
    /*private float spawnInterval = 4.0f;*/

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnRandomBall", startDelay, timer);
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int ballsIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballsIndex], spawnPos, ballPrefabs[ballsIndex].transform.rotation);
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            SpawnRandomBall();
            timer = Random.Range(3, 5);
        }
        Debug.Log(timer);

        

    }

}
