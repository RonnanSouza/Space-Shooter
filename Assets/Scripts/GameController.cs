using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float waitSpawn;
    public float waveWait;

    private int score;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    public bool gameOver;
    public bool restart;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        gameOverText.text = "";
        restartText.text = "";
        restart = false;
        gameOver = false;
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
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
        restart = true;
        restartText.text = "Press 'R' to restart";

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int newPoints)
    {
        score += newPoints;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
