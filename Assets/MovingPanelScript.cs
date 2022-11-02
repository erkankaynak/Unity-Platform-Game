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

        if (Vector3.Distance(transform.position, endPoint.position) < 2f) direction = direction * -1; // Bitiþ noktasýna çok yaklaþmýþsak artý khareket yönümüzü aksi yönde deðiþirelim.
        if (Vector3.Distance(transform.position, startPoint.position) < 2f) direction = direction * -1; // Baþlangýç noktasýna çok yaklaþmýþsak artý khareket yönümüzü aksi yönde deðiþirelim.

        transform.Translate(direction * speed * Time.deltaTime);
    }


}
