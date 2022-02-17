using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 50.;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }

        Destroy(gameObject);

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
