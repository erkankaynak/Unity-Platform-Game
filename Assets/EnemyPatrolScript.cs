using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    private Vector3 targetPoint;

    private void Start()
    {
        targetPoint = endPoint.position;
    }

    void Update()
    {
        transform.LookAt(targetPoint);

        if (targetPoint == endPoint.position && Vector3.Distance(transform.position, endPoint.position) < 2f) targetPoint = startPoint.position;
        if (targetPoint == startPoint.position && Vector3.Distance(transform.position, startPoint.position) < 2f) targetPoint = endPoint.position;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
