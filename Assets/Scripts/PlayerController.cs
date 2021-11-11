using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10;
    private float horizontalInput;
    private float meltingRate = 0.2f;
    private const float minSize = 0.8f;
    public bool gameOver = false;

    public ParticleSystem deathEffect;

    public TextMeshProUGUI gameOverText; 

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

        if (gameObject.transform.localScale.x <= minSize)
        {
            gameOver = true;
            Debug.Log("Game Over");

        }

        if (gameOver)
        {

            GameOver();

        }
        

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Obstacle") && !gameOver)
        {

            transform.localScale -= new Vector3(meltingRate * Time.deltaTime, meltingRate * Time.deltaTime, meltingRate * Time.deltaTime); 

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Snowball") && !gameOver)
        {

            Destroy(other.gameObject);
            transform.localScale += new Vector3(other.gameObject.transform.localScale.x / 10, other.gameObject.transform.localScale.y / 10, other.gameObject.transform.localScale.z / 10);

        }

    }

    public void GameOver()
    {

        Destroy(gameObject);

        Instantiate(deathEffect,transform.position,deathEffect.transform.rotation);

        deathEffect.Play();

        gameOverText.gameObject.SetActive(true);

    }


}
