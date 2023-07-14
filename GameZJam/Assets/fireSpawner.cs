using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpawner : MonoBehaviour
{
    public GameObject fire;
    public float spawnRate = 10f;
    private float timer = 0f;


    void Start()
    {
      //  StartCoroutine(StartSpawnDelay());
    }

    IEnumerator StartSpawnDelay()
    {
        
        float delayDuration = 3f;
        timer = -delayDuration;
        yield return new WaitForSeconds(delayDuration);


        while (true)
        {
            SpawnFire();
            yield return new WaitForSeconds(spawnRate);
            break;
        }
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnFire();
            timer = 0;

        }
    }
    void SpawnFire()
    {
        float lowestPoint = transform.position.y - 5;
        float highestPoint = transform.position.y + 5;
        Instantiate(fire, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

    }
}
