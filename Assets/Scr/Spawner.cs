using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawnPoint;
    public GameObject[] spawnObjects;
    public bool stopSpawning = false;
    public float timeTilNextSpawn;
    public int randomWait;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (timer <= 0)
        {
            // Spawns random Gameobject out of Array spawnObjects
            Instantiate(spawnObjects[Random.Range(0,spawnObjects.GetLength(0))], spawnPoint.transform.position, Quaternion.identity);
            timer = timeTilNextSpawn + Random.Range(0,randomWait);
        }
    }
}
