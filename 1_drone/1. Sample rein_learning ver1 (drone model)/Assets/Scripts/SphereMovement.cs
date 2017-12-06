using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float speed;
    public GameObject player;

    private Vector3 offset;
    private Rigidbody rb;
    private float speedX;
    private float speedY;
    private float speedZ;

    void Awake()
    {
        offset = player.transform.position - transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedX = offset.x;
        speedY = offset.y;
        speedZ = offset.z;
    }

    void FixedUpdate()
    {
        Vector3 movementForce = new Vector3(speedX, speedY, speedZ);
        rb.AddForce(movementForce * speed);
    }

}
