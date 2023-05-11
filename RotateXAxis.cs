using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXAxis : MonoBehaviour
{
    public float speed = 10f;
    public float xAngle = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(xAngle, 0, 0) * speed * Time.deltaTime);
    }
}
