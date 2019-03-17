using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float waitSpawn;
    public float waveWait;

    private int score;
    public Text textScore;

    void Start()
    {
        score = 0;
        UpdateScore();
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

    void UpdateScore()
    {
        textScore.text = "Score: " + score;
    }

    public void IncreaseScore(int newPoints)
    {
        score += newPoints;
        UpdateScore();
    }
}
