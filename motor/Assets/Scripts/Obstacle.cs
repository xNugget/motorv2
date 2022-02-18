using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    Motor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GameObject.FindObjectOfType<Motor>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            motor.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
