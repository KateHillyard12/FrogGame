using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public bool isJumping = false;
    public bool isPlayerOne = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveVertical = 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal = 1;
            }

            if (Input.GetKeyDown(KeyCode.S) && !isJumping)
            {
                float randomJumpForce = Random.Range(1.0f, 12.0f); // Adjust the range as needed
                rb.AddForce(new Vector3(0, randomJumpForce, 0), ForceMode.Impulse);
                isJumping = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.I))
            {
                moveVertical = 1;
            }

            if (Input.GetKey(KeyCode.J))
            {
                moveHorizontal = -1;
            }

            if (Input.GetKey(KeyCode.L))
            {
                moveHorizontal = 1;
            }

            if (Input.GetKeyDown(KeyCode.K) && !isJumping)
            {
                float randomJumpForce = Random.Range(1.0f, 12.0f); // Adjust the range as needed
                rb.AddForce(new Vector3(0, randomJumpForce, 0), ForceMode.Impulse);
                isJumping = true;
            }
        }

        Vector3 movement = transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));
        transform.position += movement * speed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
