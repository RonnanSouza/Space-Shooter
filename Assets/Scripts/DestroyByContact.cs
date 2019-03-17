using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public int pointsByAsteroid;
    private GameController gameController;
    private GameObject probableGameController;

    private void Start()
    {
        probableGameController = GameObject.FindGameObjectWithTag("GameController");
        if (probableGameController != null)
        {
            gameController = probableGameController.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Error finding 'Game Controller'!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.IncreaseScore(pointsByAsteroid);
        }
        
    }
}
