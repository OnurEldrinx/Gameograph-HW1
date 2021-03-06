using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject snowball;
    private float xBound = 3.5f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        playerController = GameObject.FindObjectOfType<PlayerController>();

        InvokeRepeating("SpawnObstacle",2,2);
        InvokeRepeating("SpawnSnowball",4,4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {

        if (!playerController.gameOver) {
            Instantiate(obstacle, new Vector3(Random.Range(-xBound, xBound), 0.05f, 60f), obstacle.transform.rotation);
        }
    }
    
    public void SpawnSnowball()
    {

        if (!playerController.gameOver)
        {

            Instantiate(snowball, new Vector3(Random.Range(-xBound, xBound), 0.5f, 50f), snowball.transform.rotation);

        }

    }
}
