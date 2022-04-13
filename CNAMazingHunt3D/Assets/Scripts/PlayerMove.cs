using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5.0f;
    private float motionUpDown;
    private float motionLeftRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        motionUpDown = Input.GetAxis("Horizontal");
        motionLeftRight = Input.GetAxis("Vertical");
        
        //move the player forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * motionLeftRight);
        transform.Translate(Vector3.right * Time.deltaTime * speed * motionUpDown);

    }
}
