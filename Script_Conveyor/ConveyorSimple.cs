using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
    public float speed = 1.5f;
    Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += Vector3.back * speed * Time.deltaTime;
        rBody.MovePosition(pos);
    }
}
