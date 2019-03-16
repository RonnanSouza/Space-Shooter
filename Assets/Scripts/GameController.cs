using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 SpawnValues;

    void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
        Quaternion SpawnRotation = Quaternion.identity;
        Instantiate(hazard, SpawnPosition, SpawnRotation);
    }
}
