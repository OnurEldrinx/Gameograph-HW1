using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (player.gameObject != null)
        {
            transform.position = player.gameObject.transform.position + new Vector3(0, 5f, -10);
        }
    }
}
