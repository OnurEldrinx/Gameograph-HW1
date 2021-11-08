using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10;
    private float horizontalInput;
    private float meltingRate = 0.2f;
    private const float minSize = 0.1f;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        if (!gameOver)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }

        if (gameObject.transform.localScale == new Vector3(minSize,minSize,minSize))
        {
            gameOver = true;
            Debug.Log("Game Over");

        }
        

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Obstacle") && !gameOver)
        {

            transform.localScale -= new Vector3(meltingRate * Time.deltaTime, meltingRate * Time.deltaTime, meltingRate * Time.deltaTime); 

        }

    }
}
