using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetect : MonoBehaviour
{
    Vector3 checkpoint;

    private Rigidbody playerRb;

    private bool respawnCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        //checkpoint = new Vector3(0, 7, 0);
        checkpoint = this.gameObject.transform.position;
        checkpoint = new Vector3(checkpoint.x, checkpoint.y + 1, checkpoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            respawnCheck = true;
        }

        if(respawnCheck == true)
        {
            playerRb.position = checkpoint;
            transform.position = checkpoint;
            
            //transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            //playerRb.velocity = Vector3.zero;
            //playerRb.angularVelocity = Vector3.zero;
            respawnCheck = false;
        }
    }
}
