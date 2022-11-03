using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    
    public float speed = 1f;
    private float timer = 2f;
    private Vector3 direction = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 3f;
            direction = -direction;
        }

        transform.Translate(direction * speed * Time.deltaTime);

    }
}
