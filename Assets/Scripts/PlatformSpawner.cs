using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;

    private Vector3 lastSpawnPos;
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPos = platform.transform.position;
        size = platform.transform.localScale.x;
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.25f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    private void SpawnPlatforms()
    {
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            SpawnPlatformX();
        }
        else
        {
            SpawnPlatformZ();
        }
    }

    private void SpawnPlatformX()
    {
        Vector3 newSpawnPos = lastSpawnPos;
        newSpawnPos.x += size;
        SpawnPlatform(newSpawnPos);
    }

    private void SpawnPlatformZ()
    {
        Vector3 newSpawnPos = lastSpawnPos;
        newSpawnPos.z += size;
        SpawnPlatform(newSpawnPos);
    }

    private void SpawnPlatform(Vector3 newSpawnPos)
    {
        lastSpawnPos = newSpawnPos;
        Instantiate(platform, newSpawnPos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(newSpawnPos.x, newSpawnPos.y + 1, newSpawnPos.z), diamond.transform.rotation);
        }
    }
}
