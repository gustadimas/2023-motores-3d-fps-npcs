using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform playerCameraTransform;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = CalculateMovement(moveHorizontal, moveVertical);
        
        if (movement.magnitude > 0f)
        {
            rb.AddForce(movement * speed);
        }
        else
        {
            rb.velocity *= 0.9f;
        }

        float mouseX = Input.GetAxis("Mouse X");
        RotateCamera(mouseX);
    }

    private Vector3 CalculateMovement(float horizontal, float vertical)
    {
        Vector3 cameraForward = playerCameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 moveDirection = (cameraForward * vertical + playerCameraTransform.right * horizontal).normalized;
        return moveDirection;
    }

    private void RotateCamera(float mouseX)
    {
        transform.Rotate(Vector3.up * mouseX);
    }
}
