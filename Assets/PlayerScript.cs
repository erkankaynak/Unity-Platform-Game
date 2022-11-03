using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;

    public GameObject panelGameOver;
    public Text textScore;

    private int gold;
    private Rigidbody rb;

    private bool isJump;
    private bool isGameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (!isGameOver)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("MovingPanel"))
            isJump = false;

        if (collision.gameObject.CompareTag("MovingPanel"))
        {
            transform.SetParent(collision.gameObject.transform, true);
        }

        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            
            panelGameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            gold++;
            textScore.text = "Golds:" + gold.ToString();
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
