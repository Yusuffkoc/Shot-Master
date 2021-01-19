using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ballRb;

    public float rotationSpeed = 5f;

    public float shootPower = 30f;

    public LineRenderer line;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ballRb.position;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;

            if (yRot < -35f)
            {
                yRot = -35f;
            }
            if (yRot > 35f)
            {
                yRot = 35f;
            }

            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 4f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ballRb.velocity = transform.forward * shootPower;
            line.gameObject.SetActive(false);
        }
    }
}
