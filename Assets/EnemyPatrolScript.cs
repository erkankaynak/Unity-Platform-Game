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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, targetPoint) < 2f)
        {
            targetPoint = targetPoint == startPoint.position ? endPoint.position : startPoint.position;
        }
    }
}
