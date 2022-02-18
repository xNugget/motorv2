using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Axel
{
    Front,
    Rear
}
[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;

}
public class MotorKontrol : MonoBehaviour
{
    [SerializeField]
    private float MaksimumHizlanma = 200f;

    [SerializeField]
    private float donusHassasiyeti = 1f;
    [SerializeField]
    private float MaksimumDonusAcisi = 45f;
    [SerializeField]
    private List<Wheel> wheels;

    private float inputX, inputY;
    public Vector3 centerOfMass;







    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
    private void LateUpdate()
    {
        Move();
        Turn();
        FrenYap();
    }
    
    void Update()
    {
        HaraketYonu();
        Tekerlerindonusu();
    }
    void HaraketYonu()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * MaksimumHizlanma * 500 * Time.deltaTime;


        }


    }
    void Turn()
    {

        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * donusHassasiyeti * MaksimumDonusAcisi;

                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, .1f);
            }
            

        }
    }
    void Tekerlerindonusu()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            // wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
    void FrenYap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 10000;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 0;
            }
        }

    }
}
