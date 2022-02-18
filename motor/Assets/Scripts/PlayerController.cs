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
<<<<<<< Updated upstream
    // Start is called before the first frame update
=======
    private float speed;
    [SerializeField] GameObject centerOfMass;
  
>>>>>>> Stashed changes
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * verticalInput * horsePower);
        transform.Rotate(Vector3.right * horizontalInput * turnSpeed * Time.deltaTime);
=======
        if (!alive)
            return;


>>>>>>> Stashed changes

        speed = playerRb.velocity.magnitude * 3.6f;

    }

    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
    }
}