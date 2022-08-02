using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    int minPosX;
    int minPosY;
    int maxPosX;
    int maxPosY;

    Timer timer;

    [SerializeField]
    GameObject prefabGreenRock;
    [SerializeField]
    GameObject prefabPinkRock;
    [SerializeField]
    GameObject prefabWhiteRock;

    const float minSpawnDelay = 0;
    const float maxSpawnDelay = 2;

    const int SpawnBorderSize = 100;

    void RockSpawn()
    {
        Vector3 location = new Vector3 (Random.Range(minPosX, maxPosX), Random.Range(minPosY, maxPosY), -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        int switcher = Random.Range(0, 3);
        GameObject RockObject;
        if (switcher == 0)
        {
            RockObject = Instantiate(prefabGreenRock) as GameObject;
        }
        else if(switcher == 1)
        {
            RockObject = Instantiate(prefabPinkRock) as GameObject;
        }
        else
        {
            RockObject = Instantiate(prefabWhiteRock) as GameObject;
        }
        RockObject.transform.position = worldLocation;
    }
    // Start is called before the first frame update
    void Start()
    {
        minPosX = SpawnBorderSize;
        minPosY = SpawnBorderSize;
        maxPosX = Screen.width - SpawnBorderSize;
        maxPosY = Screen.height - SpawnBorderSize;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(minSpawnDelay, maxSpawnDelay);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            RockSpawn();
            timer.Duration = Random.Range(minSpawnDelay, maxSpawnDelay);
            timer.Run();
        }
    }
}
