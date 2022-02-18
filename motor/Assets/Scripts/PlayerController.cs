using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public SpawnManager spawnManager;
    public float horsePower = 5.0f;
    public float turnSpeed = 5.0f;
    bool alive = true;
    private float verticalInput;
    private float horizontalInput;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
            return;

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * verticalInput * horsePower);
        transform.Translate(Vector3.right * horizontalInput * turnSpeed * Time.deltaTime);

        speed = playerRb.velocity.magnitude * 3.6f;

        if (transform.position.y < -5)
            Die();

    }

    public void Die()
    {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}