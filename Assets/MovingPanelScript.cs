using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanelScript : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    public float speed = 5f;

    public Vector3 direction;

    void Update()
    {

        if (Vector3.Distance(transform.position, endPoint.position) < 2f) direction = direction * -1; // Biti� noktas�na �ok yakla�m��sak art� khareket y�n�m�z� aksi y�nde de�i�irelim.
        if (Vector3.Distance(transform.position, startPoint.position) < 2f) direction = direction * -1; // Ba�lang�� noktas�na �ok yakla�m��sak art� khareket y�n�m�z� aksi y�nde de�i�irelim.

        transform.Translate(direction * speed * Time.deltaTime);
    }


}
