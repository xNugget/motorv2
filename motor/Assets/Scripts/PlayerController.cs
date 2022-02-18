using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public SpawnManager spawnManager;
    public float horsePower = 5.0f;
    public float turnSpeed = 5.0f;
    private float speed;
    private float verticalInput;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * verticalInput * horsePower);
        transform.Rotate(Vector3.right * horizontalInput * turnSpeed * Time.deltaTime);

        speed = playerRb.velocity.magnitude * 3.6f;

    }
   
}