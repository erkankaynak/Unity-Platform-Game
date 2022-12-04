using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanelScript : MonoBehaviour
{
    public float speed = 5f;

    public Transform startPoint;
    public Transform endPoint;

    public Vector3 direction;

    private Vector3 targetPoint;

    public void Start()
    {
        targetPoint = endPoint.position;
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 2f)
        {
            direction *= -1;
            targetPoint = targetPoint == startPoint.position ? endPoint.position : startPoint.position;
        }
    }
}
