using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZAxis : MonoBehaviour
{
    public float speed = 10f;
    public float zAngle = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, zAngle) * speed * Time.deltaTime);
    }
}

