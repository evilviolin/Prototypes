using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private Varibles
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerofMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int whelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerofMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Moves the car forward basd on vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        whelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                whelsOnGround++;
            }
        }

        if (whelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
