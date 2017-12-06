using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour
{
    Rigidbody ourDrone;

    public float upForce;
    private float movementForwardSpeed = 500.0f;
    private float tiltAmountForward = 0;
    private float tiltVelocityForward; //unnecessary
    private float wantedYRotation;
    [HideInInspector] public float currentYRotation;
    private float rotateAmountBykeys = 2.5f;
    private float rotationYVelocity;
    private Vector3 velocityToSmoothDampToZero;
    private float sideMovementAmount = 300.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;

    void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swerve();

        ourDrone.AddRelativeForce(Vector3.up * upForce);
        ourDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
            );
    }

    void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.I))
        {
            upForce = 450;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            upForce = -200;
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
        {
            upForce = 98.1f;
        }
    }
    void MovementForward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            ourDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);

        }
    }
    void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountBykeys;
        }
        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmountBykeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f); //over the time of 0.25f?
    }

    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }

    void Swerve()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
}