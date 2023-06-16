using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1.5f;
    public bool isActive = true;

    private Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            Vector3 pos = rBody.position;
            rBody.position += Vector3.left * speed * Time.deltaTime;
            rBody.MovePosition(pos);
        }
    }
}
