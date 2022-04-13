using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    public bool isOnTerrain = false;
    private float motionUpDown;
    private float motionLeftRight;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        motionUpDown = Input.GetAxis("Horizontal");
        motionLeftRight = Input.GetAxis("Vertical");
        
        //move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * motionLeftRight);
        transform.Translate(Vector3.right * Time.deltaTime * speed * motionUpDown);

        //let the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is on the ground !");
            isOnGround = true;
        }
        if(collision.gameObject.tag == "Terrain")
        {
            Debug.Log("Player is on the terrain !");
            isOnTerrain = true;
        }
    }

}
