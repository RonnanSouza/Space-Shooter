using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float waitSpawn;
    public float waveWait;

    void Start()
    {

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(hazard, SpawnPosition, SpawnRotation);
                yield return new WaitForSeconds(waitSpawn);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
        
    }
}
