using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isJump;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("MovingPanel"))
            isJump = false;

        if (collision.gameObject.CompareTag("MovingPanel"))
        {
            transform.SetParent(collision.gameObject.transform, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPanel"))
        {
            transform.SetParent(null, true);
        }
    }}
