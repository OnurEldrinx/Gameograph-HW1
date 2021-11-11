using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver) {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (gameObject.tag.Equals("Road") && gameObject.transform.position.z <= -90 && !playerController.gameOver)
        {

            gameObject.transform.position = new Vector3(0, 0, 0);

        }

        if (gameObject.CompareTag("Obstacle") && gameObject.transform.position.z <= -50 )
        {

            Destroy(gameObject);

        }

        if (gameObject.CompareTag("Snowball") && gameObject.transform.position.z <= -50)
        {

            Destroy(gameObject);

        }

        

        
    }

    

    
}
